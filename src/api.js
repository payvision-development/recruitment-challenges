const { Router } = require("express");
const { isExistMiddleware } = require("./middleweares");
const {
  existObjectMiddleware,
  notExistObjectMiddleware,
  existPlayerMiddleware,
  notExistPlayerMiddleware,
} = isExistMiddleware;
const {
  playerController,
  objectController,
  userController,
} = require("./controllers");
const api = Router();

// in order to separate objects and players I added a new level for the endpoints: object & players
// Normaly I wloud create two files : apiPlayers.js & apiObjects.js
// And in the file app: app.use("/api/player", apiPlayers);
//                      app.use("/api/object", apiObjects);
// But in the instruccions you specify to implements endpoint in **./src/api.js**

//I will separate by comments:

//USERS
api.get("/user", userController.getAllUsers);
api.post("/user/singUp", userController.register);

api.post("/user/singIn", userController.login);

//OBJECTS
api.get("/objects/", objectController.getAllObjects);
api.post(
  "/objects/createNew",
  notExistObjectMiddleware,
  objectController.createNewObject
);
api.post(
  "/objects/getById",
  existObjectMiddleware,
  objectController.getObjectById
);
api.patch(
  "/objects/updateValue",
  existObjectMiddleware,
  objectController.updateObjectValue
);
api.delete(
  "/objects/delete",
  existObjectMiddleware,
  objectController.deleteObject
);

//PLAYERS
api.get("/players/", playerController.getAllPlayers);
api.post("/players/getBugObject", playerController.getBagObjects);
api.post(
  "/players/createNew",
  notExistPlayerMiddleware,
  playerController.createNewPlayer
);
api.post(
  "/players/getById",
  existPlayerMiddleware,
  playerController.getPlayerById
);
api.patch(
  "/players/addObject",
  existPlayerMiddleware,
  existObjectMiddleware,
  playerController.addObjectInPlayerBag
);
api.patch(
  "/players/killPlayer",
  existPlayerMiddleware,
  playerController.healthDawn
);
api.patch(
  "/players/resurrectPlayer",
  existPlayerMiddleware,
  playerController.healthUp
);
api.patch(
  "/players/attackToPlayer",
  existPlayerMiddleware,
  existObjectMiddleware,
  playerController.attack
);
// api.patch(
//   "/players/killPlayer",
//   //   existPlayerMiddleware,
//   playerController.attack
// );

module.exports = api;
