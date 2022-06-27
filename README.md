# TDKRSports

## _Table of Contents_ ##

  - [General info](#general-info)
  - [Project Preview](#project-preview)
  - [Features](#features)
  - [Nouns of our project](#nouns-of-our-project)
  - [Technologies & languages](#technologies--languages)
  - [Authors](#authors)

## General info ##

<p>E-Commerce shop for taekwondo equipment</p>

## Project Preview ##

![](https://im3.ezgif.com/tmp/ezgif-3-4790d06d52.gif)

## Features ##
- Customers can look through our product catalogue online
and add one or more products to the shopping cart. Users
can also change quantities or even remove products from
the shopping cart.
- Once ready, customers can check out from the shopping
cart. After checking out, the shopping cart should be
emptied and the customer who placed the order
should see an order confirmation page that displays the
order number.
- The orders should be placed in the order system allowing
admin users to see the placed orders, so that they can
process them. The admins can see a list of outstanding
orders as well as all line items belong to any order. After
processing the order, the admins can mark an order as
processed. Any orders that are marked as processed
should not be found on the outstanding orders screen, but
should be found on the processed orders screen.


## Nouns of our project ##

Customer

**Product**

Shopping Cart

**Order**
- *OrderId*
- DatePlaced
- DateProcessing
- DateProcessed
- CustomerName
- CustomerAddress
- CustomerCity
- CustomerProvince
- CustomerCountry
- CustomerEmail
- AdminUser

**Order Line Item**
- LineItemId
- ProductId
- Price
- OrderId

User (Admin)

**Screens**:

Product Catalogue:
- Search

Product Detail:
- View
- Add Product

Shopping Cart:
- View Shopping Cart
- Change Quantity
- Remove Products from Cart
- Check Out

Order Confirmation:
- View

Outstanding Orders:
- View

Order Details:
- View
- Update Order Status

Processed Orders:
- View


## Technologies & languages ##



* C#
* Bootstrap
* .NetCore
* Blazor
* HTML 5
* CSS
* Dapper




## Authors ##
| Name | Surname | GitLink |
| ------ | ------ | ------ |
| Karlo | Rešetar | [GitHub profile KR](https://github.com/karloresetar). |
| Ivana | Čavka | [GitHub profile IČ](https://github.com/ivana-cavka). |
