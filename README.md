# Frontend Software Engineer - Rendering transactions

As a payment gateway, Payvision offers multiple APIs to process payments and credits (also known as transactions). In this code challenge, you will be in charge of creating a stunning view for **rendering transactions**. Use the technology and/or frameworks that make you feel comfortable. Don't hesitate to contact us if you have any questions regarding this challenge.

## Challenge details

Here you have the requirements for the challenge:
1. Create a web project where the user consume the **transactions endpoint**.
2. The app should render the information from the **transactions endpoint** described below.
3. Your code should be maintainable and extensible as possible.
4. Here you have the design that you have to apply. See our [zeplin page!](https://scene.zeplin.io/project/5aba58ec2ad5c9a98d97c76e)
5. Responsive is mandatory.
6. Use the technology that you consider more useful.
7. Create a readme with the explanation of how to start the project.
8. Package the solution and send to jobs.spain@payvision.com

Please, find bellow all the information of the endopoint that you should use.

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
| `action`      | `payment`, `credit`
| `currencyCode` | `EUR`, `JPY`, `USD` |

Here you have some examples:
```
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions?currencyCode=EUR
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions?action=payment
https://jovs5zmau3.execute-api.eu-west-1.amazonaws.com/prod/transactions?action=credit&currencyCode=USD
```

That's all you need to create a simple dashboard to list the transactions. There are no restrictions about the styling or extra functionalities, be creative!
