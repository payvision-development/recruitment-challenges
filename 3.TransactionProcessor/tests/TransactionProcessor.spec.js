const { transactions } = require("../src/examples");
const TransactionProcessor = require("../src/TransactionProcessor");

let processor = new TransactionProcessor(transactions);

describe("TransactionProcessor.isValidTransaction method", () => {
  test("isValidTransaction true - ok", () => {
    expect(TransactionProcessor.isValidTransaction(transactions[0])).toBe(true);
  });

  test("isValidTransaction false - ok", () => {
    expect(TransactionProcessor.isValidTransaction(transactions[3])).toBe(
      false
    );
  });
});

describe("TransactionProcessor.filterInvalidTransactions method", () => {
  beforeAll(() => {
    processor = new TransactionProcessor(transactions);
  });

  test("filterInvalidTransactions empty array - 0", () => {
    const processorEmpty = new TransactionProcessor([]);
    expect(
      processorEmpty.filterInvalidTransactions().transactions
    ).toHaveLength(0);
  });

  test("filterInvalidTransactions with valid array", () => {
    expect(processor.filterInvalidTransactions().transactions).toHaveLength(1);
  });
});

describe("TransactionProcessor.getTransactionsByCurrency method ", () => {
  beforeAll(() => {
    processor = new TransactionProcessor(transactions);
  });

  test("getTransactionsByCurrency empty array", () => {
    const processorEmpty = new TransactionProcessor([]);
    expect(
      processorEmpty.getTransactionsByCurrency("EUR").transactions
    ).toHaveLength(0);
  });

  test("getTransactionsByCurrency with valid currency", () => {
    expect(
      processor.getTransactionsByCurrency("EUR").transactions
    ).toHaveLength(1);
  });

  test("getTransactionsByCurrency with false currency", () => {
    expect(
      processor.getTransactionsByCurrency("eURo").transactions
    ).toHaveLength(0);
  });
});

describe("TransactionProcessor.getTransactionsByBrand method", () => {
  beforeAll(() => {
    processor = new TransactionProcessor(transactions);
  });

  test("getTransactionsByBrand empty array", () => {
    const processorEmpty = new TransactionProcessor([]);
    expect(
      processorEmpty.getTransactionsByBrand("visa").transactions
    ).toHaveLength(0);
  });

  test("getTransactionsByBrand with valid brand", () => {
    expect(processor.getTransactionsByBrand("visa")).toHaveLength(1);
  });

  test("getTransactionsByBrand with false brand", () => {
    expect(processor.getTransactionsByBrand("v1sa").transactions).toHaveLength(
      0
    );
  });
});

describe("TransactionProcessor.filterTransaction method", () => {
  beforeAll(() => {
    processor = new TransactionProcessor(transactions);
  });

  test("filterTransaction empty array", () => {
    const processorEmpty = new TransactionProcessor([]);
    expect(processorEmpty.filterTransaction([]).transactions).toHaveLength(0);
  });

  test("filterTransaction with predicates", () => {
    const lowAmountFilter = tx => tx.amount < 10;
    const visaFilter = tx => tx.brand === "visa";
    const euroFilter = tx => tx.currency === "EUR";

    expect(
      processor.filterTransaction([lowAmountFilter, visaFilter, euroFilter])
        .transactions
    ).toHaveLength(1);
  });

  test("filterTransaction with no result predicates", () => {
    const yenFilter = tx => tx.currency === "JPY";

    expect(processor.filterTransaction([yenFilter]).transactions).toHaveLength(
      0
    );
  });
});

describe("TransactionProcessor.sum method", () => {
  beforeAll(() => {
    processor = new TransactionProcessor(transactions);
  });

  test("sum transactions empty array", () => {
    const processorEmpty = new TransactionProcessor([]);
    expect(processorEmpty.sum()).toBe(0);
  });

  test("sum transactions valid array", () => {
    expect(processor.sum()).toBe(6.06);
  });
});

describe("Fluent method", () => {
  beforeAll(() => {
    processor = new TransactionProcessor(transactions);
  });

  test("filter empty array visa and sum", () => {
    const processorEmpty = new TransactionProcessor([]);
    expect(processorEmpty.getTransactionsByBrand("visa").sum()).toBe(0);
  });

  test("filter visa and sum", () => {
    expect(processor.getTransactionsByBrand("visa").sum()).toBe(1.01);
  });
});
