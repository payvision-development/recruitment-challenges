# Test Automation Engineer - Rendering transactions

As a payment gateway, Payvision offers multiple APIs to process payments and credits (also known as transactions). In this challenge, you will be in charge of creating a **testing plan**. Use the technology and/or frameworks that make you feel comfortable. Don't hesitate to contact us if you have any questions regarding this challenge.

## Challenge details
Here you have the requirements that you have to cover.
1. Create a test plan with all the cases that you consider.
2. Choose the best technology to implement the test cases.
3. Create a report with all the BUGS found (if needed).
4. Also, add to the report some design errors that you found.
5. Feel free to add all the information that you consider useful.
6. Package all the content that you have done.
7. Send to jobs.spain@payvision.com

Please, find bellow all the information of the API that you should use.


## Transactions endpoint

```
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions
```

This is the endpoint for retrieving transactions from the API. This is a protected endpoint; provide the following credentials using the **basic auth** mechanism.

```
Username: code-challenge
Password: payvisioner
```

This endpoint should be called with `GET` and accept filters.

| Filter name   |   Possible values |
| ---           |   ---             |
| `action`      | `payment`, `credit` |
| `currencyCode`    | `EUR`, `GBP`, `JPY`, `USD` |
| `orderBy`     | `date`, `-date`   |

Here you have some examples:
```
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions?currency=EUR
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions?action=refund
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions?action=charge&currency=USD
```
