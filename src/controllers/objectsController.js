const data = require("../data");

const { objects, players } = data;
function getAllObjects(req, res) {
  try {
    res.status(200).json(objects);
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}
function createNewObject(req, res) {
  try {
    const { body } = req;
    const { name, value } = body;
    const higherId = objects.length - 1;
    const newId = objects[higherId].id + 1;
    const object = {
      id: newId,
      name: name,
      value: value,
    };
    objects.push(object);
    res.status(200).json({
      newObject: object,
      newListObjects: objects,
    });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

function getObjectById(req, res) {
  const { objectId } = req.body;
  try {
    const objectFound = objects.filter((object) => object.id === objectId);

    return res.status(200).json(objectFound[0]);
  } catch (error) {
    return res.status(500).json({
      error_message: error.message,
    });
  }
}

function updateObjectValue(req, res) {
  const { newValue } = req.body;

  try {
    objects.map((object) => {
      object.value = newValue;
      res.status(200).send(object);
    });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

function deleteObject(req, res) {
  const { objectId } = req.body;
  try {
    let deletedObject;

    const pos = objects
      .map((object) => {
        return object.id;
      })
      .indexOf(objectId);
    if (pos > -1) {
      deletedObject = objects.splice(pos, 1);
    }
    res.status(200).send({
      deletedObject: deletedObject,
      objects: objects,
    });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

module.exports = {
  getAllObjects: getAllObjects,
  createNewObject: createNewObject,
  getObjectById: getObjectById,
  updateObjectValue: updateObjectValue,
  deleteObject: deleteObject,
};
