const data = require("../data");
const { objects, players } = data;

// middelware for OBJECTS

function existObjectMiddleware(req, res, next) {
  const { objectId } = req.body;
  try {
    const objectExist = objects.filter((object) => object.id === objectId);

    console.log(objectExist);
    if (objectExist.length === 0) {
      return res.status(404).send("the object doesn't exist");
    }
    next();
  } catch (error) {
    next(error);
  }
}
function notExistObjectMiddleware(req, res, next) {
  const { name } = req.body;
  try {
    const objectNotExist = objects.filter((object) => object.name === name);

    if (objectNotExist.length === 0) {
      next();
    } else {
      return res.status(404).send("the object already exist");
    }
  } catch (error) {
    next(error);
  }
}

// middelware for PLAYERS

function existPlayerMiddleware(req, res, next) {
  const { playerId } = req.body;
  try {
    const playerExist = players.filter((player) => player.id === playerId);

    if (playerExist.length === 0) {
      return res.status(404).send("the player doesn't exist");
    }
    next();
  } catch (error) {
    next(error);
  }
}
function notExistPlayerMiddleware(req, res, next) {
  //playerId
  const { playerId } = req.body;
  try {
    const playerNotExist = players.filter((player) => player.id === playerId);

    if (playerNotExist.length === 0) {
      next();
    } else {
      return res.status(404).send("the player already exist");
    }
  } catch (error) {
    next(error);
  }
}

module.exports = {
  existObjectMiddleware: existObjectMiddleware,
  notExistObjectMiddleware: notExistObjectMiddleware,
  existPlayerMiddleware: existPlayerMiddleware,
  notExistPlayerMiddleware: notExistPlayerMiddleware,
};
