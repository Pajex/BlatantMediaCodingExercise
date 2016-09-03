# BlatantMediaCodingExercise
Coding Exercise for Blatant Media

### Notes/Pseudocode

1. Start checkout.
  1. Load price catalogue/promotional resources.
2. Read item from file input (Unsorted/Read all items into a queue?).
  1. Determine price of item.
    1. Check price catalogue (JSON).
      1. Search for item. 
        1. If item is on sale
          - Return sale price.
        2. Else
          - Return regular price.
3. Add item to receipt (List?).
  1. If item already exists in reciept.
    - Add price of item to already existing item.
  2. Else
    - Create a new entry on the receipt.
4. Print receipt.
  1. Regular price.
  2. Discount/Savings applied.
  3. Total price $$$

### Assumptions
- A JSON file is accessible enough for GroceryCo Staff (in place of database).
