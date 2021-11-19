// This will be your data source
const data = require("../data");
const { objects, players } = data;

function getAllPlayers(req, res) {
  try {
    res.status(200).json(players);
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

function getPlayerById(req, res) {
  const { playerId } = req.body;
  try {
    const foundedPlayer = players.filter((player) => player.id === playerId);
    if (foundedPlayer) {
      res.status(200).send(foundedPlayer[0]);
    }
    // });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

function addObjectInPlayerBag(req, res) {
  const { objectId, playerId } = req.body;

  try {
    const thisPlayer = players.filter((player) => player.id === playerId);
    const existObjectPlayer = thisPlayer[0].bag.includes(objectId);

    if (existObjectPlayer) {
      res.status(200).send("this player already have this object");
    } else {
      thisPlayer[0].bag.push(objectId);
      res.status(200).send(thisPlayer[0]);
    }
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}
function healthDawn(req, res) {
  const { playerId } = req.body;
  try {
    const foundPlayer = players.filter((player) => player.id === playerId);
    if (foundPlayer[0].health === 0) {
      res.status(200).json("this player is already dead");
    } else {
      foundPlayer[0].health = 0;
      res.status(200).json(foundPlayer[0]);
    }
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

function healthUp(req, res) {
  const { playerId } = req.body;
  try {
    const foundPlayer = players.filter((player) => player.id === playerId);
    if (foundPlayer[0].health === 100) {
      res.status(200).json("this player is already live");
    } else {
      foundPlayer[0].health = 100;
      res.status(200).json(foundPlayer[0]);
    }
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}
function createNewPlayer(req, res) {
  try {
    const { body } = req;
    const { name, age, bag } = body;
    const higherId = objects.length - 1;
    const newId = objects[higherId].id + 1;
    const player = {
      id: newId,
      name: name,
      age: age,
      health: 100,
      bag: bag,
    };
    players.push(player);
    res.status(200).json({
      newPlayer: player,
      newListPlayers: players,
    });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}
function getBagObjects(req, res) {
  const { id } = req.body;
  try {
    const choosenPlayer = players.filter((player) => player.id === id);
    const playerBug = choosenPlayer[0].bag;

    res.status(200).send(playerBug);
  } catch (error) {
    res.status(500).send({
      error_message: error.message,
    });
  }
}

function attack(req, res) {
  const { objectId, playerId } = req.body;

  try {
    const playerToAtack = playerId;
    const choosenPlayer = players.filter(
      (player) => player.id === playerToAtack
    );
    const objectWeapon = objects.filter((object) => object.id == objectId);
    const damage = objectWeapon[0].value;
    choosenPlayer[0].health = choosenPlayer[0].health + damage;
    res.status(200).send(choosenPlayer[0]);
  } catch (error) {
    res.status(500).send({
      error_message: error.message,
    });
  }
}
module.exports = {
  getAllPlayers: getAllPlayers,
  createNewPlayer: createNewPlayer,
  getPlayerById: getPlayerById,
  addObjectInPlayerBag: addObjectInPlayerBag,
  healthDawn: healthDawn,
  healthUp: healthUp,
  getBagObjects: getBagObjects,
  attack: attack,
};
