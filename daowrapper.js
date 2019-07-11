const Dao = require("./dao.js");

module.exports = class DaoWrapper extends Dao {
  constructor(pool) {
    super(pool);
  }

  createOne(json, callback) {
    var val = [json.player_id, json.try_nr, json.point1, json.point2, json.point3,
      json.point4, json.point5, json.point6, json.point7, json.point8];
    console.log("value: " + val);
    super.query(
      "insert into 9dotproblem (player_id, try_nr, point1, point2, point3, " +
      "point4, point5, point6, point7, point8) values (?,?,?,?,?,?,?,?,?,?)",
      val,
      callback
    );
  }
};
