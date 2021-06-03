# CS 355 Database Systems, Fall 2020
# Final Project: Covserve Shop

The final project for this course required the implementation of a database in an application.

## Group Members:
- _Aliza Rafique_
- _Wasiq Hussain_

## Youtube Demo Link

https://youtu.be/rk1ZzheJaM8

## Background

Since the outset of the global COVID-19 pandemic, students from different fields have put forward unique solutions to various problems created by the pandemic. One of the major problems was access to necessary precautionary and self-care items. Amid the lockdown, when shops and markets were closed or visiting them in-person was not safe, people needed a safe place to get their masks, sanitizers, gloves, and other necessary precaution gear. The need of the time was an online system with access to all precautionary items in one place. Covserve is our answer to this problem. Covserve is a Database System where suppliers can add all their products to the database while customers can search their favorite items in the inventory and purchase them.

## Application

The application will provide a user-friendly and interactive GUI to both Supplier and Customer. From adding items in the inventory to purchasing them, the application has been designed in a way that the user does not face any difficulty.

## Application Usage

The application starts with an opening screen asking if the user is a supplier or customer. Upon selecting any one option, the respective Sign In / Sign Up screen will open. If the user prompts for sign up, the register form prompts the user to enter their details like Name, Email, and Password. The form is submitted and an account is created. Otherwise, the user will sign in with his registered credentials. Depending upon if the user is a supplier or customer, the respective Dashboard screen will open next.

### What can the supplier do?

The supplier can upload item(s) to sell. A registered supplier can upload an item to the database to sell through the application. The system prompts the supplier for item photos, item category, and item details like name, price, and quantity. Then the item is added to the inventory. Only the supplier can change data related to his uploaded items or delete them.

### What can the customer do?

Each customer has a Shopping Cart where he can add/remove selected items from inventory. Add button on the main inventory screen prompts the system to add the item to the user’s cart. All consequent item(s) added without checkout, are added to the same cart unless cleared. The Clear button allows the user to remove a previously added item from the cart. If the cart is empty, the checkout button will be inactive. After the customer completes the checkout process, he will need to select the payment method to confirm the order.  
