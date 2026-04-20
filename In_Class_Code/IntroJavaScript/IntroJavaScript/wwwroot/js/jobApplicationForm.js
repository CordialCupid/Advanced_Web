'use strict';

import { DOMManipulator } from "./DOMManipulator";

console.log("Testing");
DOMManipulator.demonstrateDOMSelectors();

let dom = new DOMManipulator();
dom.setUpEventListeners();