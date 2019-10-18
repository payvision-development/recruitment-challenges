const { Router } = require("express");
const api = Router();

// This will be your data source
const players = [
  { id: 1, name: "Jon Snow", age: 23, health: 100, bag: [1] },
  { id: 2, name: "Littlefinger", age: 35, health: 100, bag: [2] },
  { id: 3, name: "Daenerys Targaryen", age: 20, health: 100, bag: [3] },
  { id: 4, name: "Samwell Tarly", age: 18, health: 100, bag: [4] }
];
const objects = [
  { id: 1, name: "spoon", value: -1 },
  { id: 2, name: "knife", value: -10 },
  { id: 3, name: "sword", value: -20 },
  { id: 4, name: "potion", value: +20 }
];

// EXAMPLE ENDPOINT: LIST ALL OBJECTS
api.get("/objects", function(req, res) {
  res.json(objects);
});

module.exports = api;

// ************************************************************************

// RULES:

// You are free to implement as many endpoints as you need.
// You can use inline comments, git commits or readme file to justify your decissions.
// Bag size is unlimited.
// Bear in mind RESTful API concepts.
// One object can be used by multiple players
// Use your own criteria for any rule that is not clear. Justify it.

// PLEASE, DO NOT INCLUDE ALL THIS COMMENTED CODE IN YOUR CODE.

// ************************************************************************

// YOUR TASKS:

// LIST ALL PLAYERS
// CREATE PLAYER: adds a new player to data source
// GET PLAYER BY ID: returns a player
// ASSIGN OBJECT: arm a player with a new object in its bag
// KILL PLAYER: remove from data source

// CREATE OBJECT: add a new weapon to use
// GET OBJECT BY ID: returns specified object
// IMPROVE OBJECT: increase/descrease the value of the object with a new value
// DELETE OBJECT: remove an object from available objects

// ************************************************************************

// BONUS:
// You will get extra points if you implement this methods:

// ATTACK PLAYER: one player attacks another player using an object from its bag. Adjust health accordingly
// STEAL BAG: one player steals everything from another player. Bag objects are moved from one player to another.
// RESURECT PLAYER: bring back to live a dead player using its id.
// USE OBJECT: a player use an object against another player or itself.

// ************************************************************************

// SUPER BONUS:
// Are you having fun? You are free to extend the game with new functionality.
// YOUR OWN METHOD: ...

// ************************************************************************
