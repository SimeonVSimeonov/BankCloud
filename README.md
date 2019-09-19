# BankCloud
BankCloudApp Virtual bank system for individual and business clients
BankCloudApp is published on  http://bankcloud.azurewebsites.net/
User profile : pesho@mail.bg , pass: Ger100100@
Agent profile : gosho@mail.bg , pass: Ger100100@
If you want, you can sign up for free :)

# Project - BankCloud

## Type - Virtual Bank System

## Description

This is a virtual bank system project which 
sells financial products such as Loans, Mortgage, Cards, 
Deposit(saves), Investemnt etc. Guest Users can register
and login to their accounts.
Regular Users can view and order financial products with quantity and type.
Regular Users can order products by creating a contract 
with a bank company and make ask for credit scoring.
The project also supports Brokers. 
Brokers have all rights a Regular User has.
Brokers can also Promote and Demote Users.
Brokers can also add, edit or delete financial products and curency. 
Brokers can also make changes on user contracts if 
he make ask for refinancing. 
Brokers and User can watch the market for changes.

## Entities

### User
  - Id (string)
  - Username (string)
  - Password (string)
  - Email (string)
  - Full Name (string)
  - Phone Number (string)
  - Product products (collection)
  - Order Order (collection)
  - Credi scoring CreditScoring (collection)
### Product
  - Id (string)
  - Name (string)
  - Curency (Curency)
  - Balance (decimal)
  - Type (Type) (loan/mortgage, card, deposit(saves), investment, insurance, creditLine, payments)
  - Price (decimal)
  - Asset (decimal)
  - Liabilities (decimal)
### Order
  - Id (string)
  - IssuedOn (dateTime)
  - CompletedOn (dateTime)
  - Product (Product)
  - User (User)
  - CostPrice (decimal)
  - Status (enum)
### Curency
  - Id (string)
  - Name (string)
  - Type (enum)
  - ТrustLevel (int)
  - Exchange (calc prop)
### CreditScoring
  - Id (string)
  - Level (string)
  - Issued On (dateTime)
  - Active Until (dateTime)
  - CostPrice (decimal)
  - Order (Order)
  - Contractor (User)
### MarketWatch
  - Id (string)
  -	StocksMarket(collection)
  - InterestsRateMarket (collection)
  - ForexMarket (collection)
