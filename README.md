# Software Engineer - JS

Here you have the challenge for the software engineer position. You can find in this branch two different challenges, an algorithm one another one to see how you can refactor a dirty code. If you think that you can solve it using some design patters, feel free and apply them. Let's go! :sunglasses:


# 1- Refactoring fraud detection
Refactor the FraudRadar class. You can make any changes you see that are needed in code or tests. See the tests for more information.

### Code **Requirements**:
* All the tests must pass.
* The code must fulfil <mark>**OOP**</mark> and <mark>**SOLID**</mark> principles.
* The code must be **maintainable**.
* The code must be **extensible**.
* You must apply **defensive programming** practices.
* Receiving the file path is not nice. Think about it and change the signature, let's make it cooler.


# 2- Counting bits
Given an integer, n, we want to know the following:
1. How many 1-bits are in its binary representation?
2. Let's say n's binary representation has k significant bits indexed from 1 to k. What are the respective positions (i.e., in ascending order) of each 1-bit?
3. The performance is really important in this challenge.


### Example

Complete Count function in PositiveBitCounter class. It has one parameter: an integer, n. It must return an integer enumerable with the following 1 + k values:
* The first index (0) must contain the total number of 1 bits in n's binary representation.
* The subsequent indices must contain the respective positions of the one-indexed 1-bits in n's binary representation.

### Output format

Return an enumerable of integers where the first element is the total number of 1-bits in n's binary representation and the subsequent elements are the respective one-indexed locations of each 1-bit from most to least significant.

### Tips

The integer n = 161 converts to binary.

1 | 0 | 1 | 0 | 0 | 0 | 0 | 1
---|---|---|---|---|---|---| ---|

Reverse the binary representation.

1 | 0 | 0 | 0 | 0 | 1 | 0 | 1
---|---|---|---|---|---|---| ---|

Count number of positive bits: 3
Search the position: 0, 5, 7
Return { 3, 0, 5, 7 }