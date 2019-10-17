class TransactionProcessor {
  // QUESTION: COMPLETE ALL CLASS FUNCTIONS TO PASS THE TESTS

  constructor(transactions) {
    this.transactions = transactions;
  }

  print(tx) {
    console.log(
      `ID: ${tx.id} - Brand: ${tx.brand} - Currency: ${tx.currency} - Amount: ${tx.amount}`
    );
  }

  // Check valid transactions rules
  static isValidTransaction(transaction) {
    // ...
    return true;
  }

  // Remove invalid transactions
  filterInvalidTransactions() {
    // ...
    return this;
  }

  // Return transactions of given currency
  getTransactionsByCurrency(currency) {
    // ...
    return this;
  }

  // Return transactions of given brand
  getTransactionsByBrand(brand) {
    // ...
    return this;
  }

  // BONUS:
  // Apply multiple filters. Filters parameter should be an array of functions (predicates)
  filterTransaction(filters) {
    // ...
    return this;
  }

  // Return the total amount of current transactions array
  sum() {
    return 0;
  }
}

module.exports = TransactionProcessor;
