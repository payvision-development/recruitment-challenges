const transactions = require("./src/examples/transactions");
const TransactionProcessor = require("./src/TransactionProcessor");

console.log("*** Payvision transaction processor ***");
const processor = new TransactionProcessor();

transactions.forEach(tx => {
  processor.print(tx);
  // Have fun!
  // ...
});
