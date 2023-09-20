# Project: Currency converter
## Functional requirements
- The system should contain a list of currencies, which, if necessary, can be replenished by indicating the full name of the currency, its abbreviation (three letters usually formed from its name), the issuing country and the exchange rate.
  - An exchange rate is created for a currency pair and indicates the cost of exchanging currency1 for currency2.
  - An attempt to exchange a currency for another for which the rate is not specified results in an error.
  - The exchange rate is updated every day. It is necessary that the exchange rate for each specific currency displays the most current pairs in which that currency appears.
- You can only add a course to the database for the current or previous days. In this case, when you try to add a course that is already included in the database, priority is given to the existing one.
- It is necessary to provide the ability to obtain changes in the exchange rate as a percentage between certain dates or for the last month.
## Entities
- **Exchange Rate**. Determined for a specific day for a specific currency pair. Contains the date for which it was relevant, links to the currencies participating in it and the price of their exchange for each other.
- **Currency**. It has a full name, an abbreviation (the three letters usually formed from the name), the issuing country and a list of all exchange rates in which it appears.
## Sidenotes
A small project written during a 1-month internship in Akvelon. The main emphasis was on code cleanliness, ability to work with Git and understanding of REST and OOP.
