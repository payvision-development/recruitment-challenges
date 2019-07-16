# Fullstack Software Engineer

We are looking for **senior fullstack** developers

As a **senior developer** you know that this is not only about code. We care about all the aspects involved in development

As a **fullstack developer** you have experience working with frontend and backend technologies

# What we expect from you?

We want you to implement the project described below

* This is a fullstack challenge, so is a frontend app enough?

* Documentation included in the repo please! What? Why? How? How to install, how to run tests, how to run the challenge?

* We will value interesting software design / architecture

# Tech stack

We have our favourites. Anyway, you can choose your own stack :)

**Frontend:** Angular, Vue

**Backend:** .NET, Node

We are lazy and we will not install anything, does Docker ring a bell?

# The challenge

As a payment gateway, Payvision offers multiple APIs to process payments and credits (also known as transactions). 

Don't hesitate to contact us if you have any questions regarding this challenge.

## Functional Description

* Consume the **transactions endpoint** described below
* Render the information in a web application

## UI requirements
* UI design. See our [zeplin page!](https://scene.zeplin.io/project/5aba58ec2ad5c9a98d97c76e)
* Responsive

## Security
* Do not expose our API credentials

## Delivery
* Documentation in english is mandatory
* Package the solution and send it to **jobs.spain@payvision.com**

## Limitations
No limits, be creative!

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
