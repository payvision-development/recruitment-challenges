const { Router } = require("express");
const router = Router();

router.get("/health", function (req, res) {
  res.body = "Up and running";
  res.send(res.body);
  // QUESTION: why this endpoint blocks the app?
  //Becouse you need to use a method of res object -->.send() or .json()
  // json() method it can be used to JSON conversion of non-objects (null, undefined, etc.)
  //
});

module.exports = router;
