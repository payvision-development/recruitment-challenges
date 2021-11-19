const data = require("../data");
const bcrypt = require("bcrypt");
const { users } = data;
function getAllUsers(req, res) {
  try {
    res.status(200).json(users);
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

async function register(req, res) {
  const { body } = req;
  const { name, age, email, password } = body;
  let newId;
  try {
    const salt = await bcrypt.genSalt(10);
    if (users.length === 0) {
      newId = 1;
    } else {
      const higherId = users.length - 1;
      newId = users[higherId].id + 1;
    }
    const encrypted = await bcrypt.hash(password, salt);

    const user = {
      id: newId,
      name: name,
      age: age,
      email: email,
      password: encrypted,
    };
    users.push(user);
    res.status(200).json({
      newUser: user,
      newListUsers: users,
    });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

function login(req, res) {
  const { body } = req;
  const { email, password } = body;
  try {
    users.map((user) => {
      if (user.email === email) {
        console.log(user.email);
        bcrypt.compare(password, user.password).then((isExist) => {
          console.log(isExist);
          if (isExist) {
            console.log("entro");
            return res.send("welcome " + user.name);
          } else {
            return res.status(500).json({
              message: "incorrect password",
            });
          }
        });
      } else {
        return res.status(404).json({
          message: "Please register",
        });
      }
    });
  } catch (error) {
    res.status(500).json({
      error_message: error.message,
    });
  }
}

module.exports = {
  register: register,
  login: login,
  getAllUsers: getAllUsers,
};
