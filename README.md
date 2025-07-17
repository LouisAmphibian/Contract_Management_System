# Contractly- Contract Monthly Claim System (CMCS)

# Description
**Contractly**  is a Contract Monthly Claim System (CMCS) is a software application designed to simplify the management and processing of monthly claims linked to existing or new contract. It simplifies and automates the processes of submitting, approving, and tracking monthly claims. The system provides complete visibility into payment statuses and maintains a detailed audit trail of all transactions and administrative actions.

## Prerequisites
###Online
Visit this site:  https://louisamphibian.github.io/Contract_Management_System/

###Local 
- Make sure you have [.NET SDK](https://dotnet.microsoft.com/download) installed.
- Make sure you have Visual Studio community(https://visualstudio.microsoft.com/vs/community/) installed

## Installation of application/project
1. Clone this repository (https://github.com/your-repo/CMCS.git) to your local machine.
2. Navigate to the project directory.
3. Locate the solution explorer
4. Double click or open the CMCS.sln

## Building the Software
1. After opening or double clicking the CMCS.sln
3. Press Crtl B to Build .

## Running the Software
1. After building the project, navigate the Debug drop menu
2. The click on Start Debugging or Start Without Debug

## Screen shot
![Contractly](https://github.com/user-attachments/assets/e6e1df82-17e0-47a9-9e23-82cf22f6163a)



## Contributing
Pull requests are welcome. No major changes, please open an issue first to discuss what you would like to change.

## License
[MIT](https://choosealicense.com/licenses/mit/)

### [24-October-2024]

### Features Added:
1. The system allows gym staff to manage member contracts, claims, and payments.
2. Each member can have multiple contracts, but only one active contract at a time.
3. The system generates monthly claims for each active contract.
4. Claims can be approved, denied, or pending, and the system tracks the status of each claim.
5. Payments are linked to claims, and the system tracks the payment method, status, and transaction reference.
6. Administrators can manage claims, approve payments, and issue refunds.
7. The system maintains a comprehensive audit trail of all transactions, including administrator actions.

#### Non-functional requirements:
8. Internationally acceptable coding standards are adhered to.
9. Classes are used throughout the application.
10. Generic collections are utilized instead of arrays for storing data.
11. A delegate is implemented to notify administrators of claim status changes.
12. Unit tests are created to verify the accuracy of claim and payment calculations.
