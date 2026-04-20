using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using LecControllers.Models;
using System.Text;

namespace LecControllers.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    // routes to home/idcheck/[id]
    public IActionResult IdCheck(string? id)
    {
        var model = "No Id";
        if(id != null)
        {
            model = $"Id: {id}";
        }
        return Content(model);
    }

    public IActionResult FourSegments(string code, string idNumber)
    {
        ViewData["code"] = code;
        ViewData["idNumber"] = idNumber;
        return View();
    }

    public IActionResult Details(string enumber)
    {
        ViewData["ENumber"] = enumber;
        return View();
    }

    public IActionResult Variable(string? name, string? values)
    {
        ViewData["result"] = $"name={name} values={values}";
        // string[] itemArray = (values != null)?values.Split("/"):[];
        string[] itemArray = values!.Split("/");
        ViewData["itemStr"] = String.Join(" ", itemArray);
        return View();
    }

	[HttpGet]
	public IActionResult InputAgeForm()
	{
		return View();
	}
	
	[HttpPost]
	public IActionResult FormProcessor(int age)
	{
        // Some major processing
		return RedirectToAction("Age", new { id = age });
	}

    // even though its coming in as age, bind it to id to improve its readablity (turns into http://localhost:5293/Home/Age/12)
    public IActionResult Age([Bind(Prefix="id")]int age)
    {
        return Content($"The age is {age}.");
    }

    // Tell it File and MIME type
    public IActionResult FileDemo()
    {
        return File("Doc1.pdf", "application/pdf");
    }

    public IActionResult JsonDemo()
    {
        return Json(new { id=1, name="will", type="person"});
    }

    public IActionResult ClientSideSave() 
    {
        return View();
    }
    
    // not expected to memorize
    public IActionResult FileSaveDemo()
    {
        string stringToSave = "This is the data to save!\n";
        byte[] bytesToSave = Encoding.UTF8.GetBytes(stringToSave);
        MemoryStream ms = new();
        ms.Write(bytesToSave, 0, bytesToSave.Length);
        ms.Position = 0;
        string path = "somefile.txt";
        return File(ms, "application/octet-stream", Path.GetFileName(path));
    }

    public IActionResult FileUploadDemo()
    {
        return View();
    }


    [HttpPost]
    public async Task<IActionResult> DoUpload(IList<IFormFile> files)
    {
        IFormFile? fileToImport = files.FirstOrDefault();
        if(fileToImport == null)
        {
            return RedirectToAction("ShowFileContent", new {id = "No file seleted."});
        }
        MemoryStream ms = new();
        await fileToImport.OpenReadStream().CopyToAsync(ms);
        var bytes = ms.ToArray();
        var fileContent = Encoding.UTF8.GetString(bytes);
        return RedirectToAction("ShowFileContent",
            new { id = fileContent });   
    }


    public IActionResult ShowFileContent([Bind(Prefix = "id")]string fileContent)
    {
        return Content(fileContent);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
