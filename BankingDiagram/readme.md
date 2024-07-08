### LoanApplication

**Description**: Represents a loan application submitted by a customer.

**Attributes**:

- `application_id`: Unique identifier for the loan application.
- `customer_id`: Unique identifier for the customer applying for the loan.
- `loan_type`: Type of loan (Secured,UnSecured).

- `remarks`: Additional remarks or notes related to the application.

## Service methods for loan Application

### 1. Validating Borrower Details

#### Method: `validateBorrowerDetails(borrower_details)`

- **Description**: Validates the details of the borrower.
- **Parameters**: `borrower_details` (dictionary containing borrower's information)
- **Steps**:
  1. Check the borrower’s credit score.
  2. Verify the borrower’s identity and financial status.
  3. Ensure all required documents are submitted.

---

### 2. Processing the Loan Application

#### Method: `processLoanApplication(application_id, status)`

- **Description**: Processes the loan application by a loan officer (approve/reject).
- **Parameters**:
  - `application_id` (identifier of the loan application)
  - `status` (new status of the application, e.g., approved, rejected)
- **Steps**:
  1. Retrieve the application from the database.
  2. Perform necessary checks and validations.
  3. Update the status of the application based on the loan officer’s decision.

### 3. Generating Loan Terms

#### Method: `generateLoanTerms(loan_amount, loan_duration, interest_rate)`

- **Description**: Generates the loan terms based on the loan amount, duration, and interest rate.
- **Parameters**:
  - `loan_amount` (amount of the loan)
  - `loan_duration` (duration of the loan repayment)
  - `interest_rate` (interest rate applicable)
- **Steps**:
  1. Calculate the monthly installment.
  2. Create a repayment schedule.
  3. Document the terms and conditions.

---

### 4. Notifying the Customer

#### Method: `notifyCustomer(application_id, status, remarks)`

- **Description**: Notifies the customer about the status of their loan application.
- **Parameters**:
  - `application_id` (identifier of the loan application)
  - `status` (status of the application)
  - `remarks` (additional remarks or notes)
- **Steps**:
  1. Retrieve customer contact details.
  2. Prepare the notification message.
  3. Send the notification (e.g., email, SMS).

---

### 5. Disbursing the Loan

#### Method: `disburseLoan(loanDTO)`

- **Description**: Disburses the approved loan to the customer’s account.
- **Parameters**: `loanDTO` (contains details of the loan)
- **Steps**:

  1. Validate the final loan details.
  2. Transfer the loan amount to the customer’s account.
  3. Update the loan status to disbursed.

### UnsecuredLoanApplication(Loan-Sub-Class)

**Description**: Represents an application for an unsecured loan submitted by a customer.

**Attributes**:

- `unsecured_loan_id`: Unique identifier for the loan Id.
- `application_id`: Unique identifier for the loan application.

- `loan_amount`: Amount of money requested by the customer.
- `application_date`: Date when the loan application was submitted.
- `loan_duration`: (str) Duration over which the loan is repaid (e.g., 5 years).
  `repayment_terms`: (str) Terms of repayment (e.g., Standard).
- `status`: Status of the application (e.g., pending, approved, rejected).
- `credit_score`: Credit score of the customer at the time of application.
- `income`: Customer's monthly or annual income.
- `purpose`: Purpose of the loan (e.g., debt consolidation, medical expenses).
- `documents`: List of documents submitted with the application (e.g., proof of income, ID proof).
- `remarks`: Additional remarks or notes related to the application.

# Unsecured Loan Application Module

## Layers, Interfaces, and Methods

### Controller Layer

**Interface: UnsecuredLoanApplicationController**

- **Methods**:
  - `applyForUnsecuredLoan(UnsecuredLoanApplicationDTO applicationDTO)`: Endpoint for submitting a new unsecured loan application.
  - `getUnsecuredLoanApplicationById(String applicationId)`: Endpoint for retrieving a specific unsecured loan application by its ID.
  - `updateUnsecuredLoanApplicationStatus(String applicationId, String status)`: Endpoint for updating the status of a loan application.
  - `getAllUnsecuredLoanApplications()`: Endpoint for retrieving all unsecured loan applications.

### Service Layer

**Interface: UnsecuredLoanApplicationService**

- **Methods**:
  - `submitUnsecuredLoanApplication(UnsecuredLoanApplicationDTO applicationDTO)`: Handles the submission of a new unsecured loan application.
  - `findUnsecuredLoanApplicationById(String applicationId)`: Retrieves a specific unsecured loan application by its ID.
  - `changeUnsecuredLoanApplicationStatus(String applicationId, String status)`: Updates the status of a loan application.
  - `listAllUnsecuredLoanApplications()`: Retrieves all unsecured loan applications.

### Repository Layer

**Interface: UnsecuredLoanApplicationRepository**

- **Methods**:
  - `Add(UnsecuredLoanApplication application)`: Saves a new unsecured loan application.
  - `GetById(String applicationId)`: Finds an unsecured loan application by its ID.
  - `Update(application DTO)`: Updates the status of an unsecured loan application.
  - `GetAll()`: Retrieves all unsecured loan applications.

## Endpoints and DTO

### Endpoints

- **POST /unsecured-loans/apply**: Submits a new unsecured loan application.
- **GET /unsecured-loans/{applicationId}**: Retrieves a specific unsecured loan application by its ID.
- **PUT /unsecured-loans/{applicationId}/status**: Updates the status of a loan application.
- **GET /unsecured-loans**: Retrieves all unsecured loan applications.

### DTO: UnsecuredLoanApplicationDTO

- `unsecured_loan_id`: Unique identifier for the loan Id.
- `application_id`: Unique identifier for the loan application.
- `loan_amount`: Amount of money requested by the customer.
- `application_date`: Date when the loan application was submitted.
- `loan_duration`: Duration over which the loan is repaid (e.g., 5 years).
- `repayment_terms`: Terms of repayment (e.g., Standard).
- `status`: Status of the application (e.g., pending, approved, rejected).
- `credit_score`: Credit score of the customer at the time of application.
- `income`: Customer's monthly or annual income.
- `purpose`: Purpose of the loan (e.g., debt consolidation, medical expenses).
- `documents`: List of documents submitted with the application (e.g., proof of income, ID proof).
- `remarks`: Additional remarks or notes related to the application.

### SecuredLoan Class (Sub Class of Loan)

**Attributes**:

- `secured_loan_id`: .
- `application_id`: Unique identifier for the loan application.
- `loan_amount`: (float) Total amount of the loan.

- `repayment_terms`: (str) Terms of repayment (e.g., Standard).
- `loan_duration`: (str) Duration over which the loan is repaid (e.g., 5 years).
- `borrower_details`: (dict) Dictionary containing details about the borrower (name,id, credit score and other details).
- `application_date`: Date when the loan application was submitted.
- `cosigner`: (str, optional) Another party who guarantees the loan.
- `collateral`: (str, optional) Type of collateral provided for the loan (e.g., Property).
- `DownPayment`: (str, optional) Down Payment paid for the property or anything.

- `collateral_value`: (float, optional) Value of the collateral provided.

### 1. Submitting a Secured Loan Application

#### Method: `submitSecuredLoanApplication(securedLoanApplicationDTO)`

- **Description**: Submits a new secured loan application.
- **Parameters**: `securedLoanApplicationDTO` (contains details of the loan application)
- **Steps**:
  1. Validate the application details.
  2. Save the application to the database.
  3. Return a confirmation of submission.

### 2. Evaluating Collateral

#### Method: `evaluateCollateral(collateral, collateral_value)`

- **Description**: Evaluates the provided collateral and its value.
- **Parameters**:
  - `collateral` (type of collateral provided)
  - `collateral_value` (declared value of the collateral)
- **Steps**:

  1. Inspect the collateral.
  2. Verify the authenticity and value of the collateral.
  3. Document the evaluation findings.

  ### Repository Layer

**Interface: SecuredLoanApplicationRepository**

- **Methods**:

  - `Add(SecuredLoanApplication application)`: Saves a new secured loan application.
  - `GetById(String applicationId)`: Finds an Secured loan application by its ID.
  - `Update(application DTO)`: Updates the status of an secured loan application.
  - `GetAll()`: Retrieves all secured loan applications.

  ## Endpoints

### Submit Secured Loan Application

- **POST** `/secured-loan-applications`
  - Description: Submits a new secured loan application.
  - Method: `submitSecuredLoanApplication(securedLoanApplicationDTO)`

### Validate Borrower Details

- **POST** `/secured-loan-applications/{application_id}/validate`
  - Description: Validates the details of the borrower for a specific secured loan application.
  - Method: `validateBorrowerDetails(borrower_details)`

### Process Loan Application

- **PUT** `/secured-loan-applications/{application_id}/process`
  - Description: Processes a secured loan application by a loan officer (approve/reject).
  - Method: `processLoanApplication(application_id, status)`

### Evaluate Collateral

- **POST** `/secured-loan-applications/{application_id}/evaluate-collateral`
  - Description: Evaluates the provided collateral for a specific secured loan application.
  - Method: `evaluateCollateral(collateral, collateral_value)`

### Generate Loan Terms

- **POST** `/secured-loan-applications/{application_id}/generate-loan-terms`
  - Description: Generates loan terms for a specific secured loan application.
  - Method: `generateLoanTerms(loan_amount, loan_duration, interest_rate)`

### Notify Customer

- **POST** `/secured-loan-applications/{application_id}/notify-customer`
  - Description: Notifies the customer about the status of their secured loan application.
  - Method: `notifyCustomer(application_id, status, remarks)`

### Disburse Loan

- **POST** `/secured-loan-applications/{application_id}/disburse`
  - Description: Disburses the approved secured loan amount to the customer’s account.
  - Method: `disburseLoan(loanDTO)`

# DTO's

## SecuredLoanApplicationDTO

### Attributes

- **application_id**: (int) Unique identifier for the loan application.
- **loan_amount**: (float) Total amount of the loan.
- **repayment_terms**: (str) Terms of repayment (e.g., Standard).
- **loan_duration**: (str) Duration over which the loan is repaid (e.g., 5 years).
- **borrower_details**: (dict) Dictionary containing details about the borrower (name, id, credit score, and other details).
- **application_date**: (date) Date when the loan application was submitted.
- **cosigner**: (str, optional) Another party who guarantees the loan.
- **collateral**: (str, optional) Type of collateral provided for the loan (e.g., Property).
- **DownPayment**: (float, optional) Down payment paid for the property or anything.
- **collateral_value**: (float, optional) Value of the collateral provided.

### Loan

**Description**: Represents an approved unsecured loan that has been disbursed to a customer.

**Attributes**:

- `loan_id`: Unique identifier for the loan.
- `acc_id`: Account for which loan is initiated
- `loanofficer_id`: Officer who validated and processed the loan application
- `Loan Type`: Unique identifier for the associated loan application.
- `Loan Type Id`: Unique identifier for the type
- `loan_amount`: Amount of money disbursed to the customer.
- `disbursement_date`: Date when the loan was disbursed.
- `repayment_term`: Repayment term (e.g., 12 months, 5 years).
- `interest_rate`: Interest rate applied to the loan.
- `monthly_installment`: Monthly installment amount to be repaid by the customer.
- `remaining_balance`: Remaining balance of the loan.
- `repayment_schedule`: Detailed schedule of repayment dates and amounts.
- `Initiated_Repayments`: List of repayments made for loan amount
- `Loan Status` : Shows the status of the Loan (active, closed)

# Loan Module Structure

## Controller Layer

### Interface: LoanController

#### Methods:

- `initiateLoan(LoanDTO loanDTO)`: Initiates a new loan.
- `getLoanById(String loanId)`: Retrieves a specific loan by its ID.
- `updateLoan(LoanDTO loanDTO)`: Updates loan details.
- `getLoanRepaymentSchedule(String loanId)`: Retrieves the repayment schedule of a loan.
- `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
- `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
- `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
- `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
- `getAllLoans()`: Retrieves all loans.
- `requestLoanStatement(String loanId)`: Provides a detailed statement of a loan.
- `getLoanHistoryForCustomer(String customerId)`: Retrieves loan history for a customer.
- `notifyLatePayment(String loanId)`: Notifies the borrower of a late payment.
- `getAllActiveLoans()`: Retrieves all active loans.
- `calculateRemainingBalance(String loanId)`: Calculates the remaining balance of a loan.
- `makeRepayment(String loanId, BigDecimal repaymentAmount)`: Registers a repayment.
- `applyInterestAccrual(String loanId)`: Applies interest accrual to a loan.
- `notifyUpcomingPayments(String loanId)`: Notifies the borrower of upcoming payments.
- `closeLoan(String loanId)`: Closes a loan.
- `approveLoanModificationRequest(String loanId, ModificationDetailsDTO modificationDetails)`: Approves a loan modification request.
- `rejectLoanModificationRequest(String loanId, String reason)`: Rejects a loan modification request.
- `reviewLoanDefaultRisk(String loanId)`: Reviews the default risk of a loan.

## Service Layer

### Interface: LoanService

#### Methods:

- `initiateLoan(LoanDTO loanDTO)`: Initiates a new loan.
- `findLoanById(String loanId)`: Retrieves a specific loan by its ID.
- `updateLoan(LoanDTO loanDTO)`: Updates loan details.
- `generateRepaymentSchedule(String loanId)`: Generates and retrieves the repayment schedule of a loan.
- `updateRepaymentSchedule(String loanId, RepaymentScheduleDTO scheduleDTO)`: Updates the repayment schedule of a loan.
- `updateRemainingBalance(String loanId, BigDecimal remainingBalance)`: Updates the remaining balance of a loan.
- `updateInterest(String loanId, BigDecimal interestRate)`: Updates the interest rate of a loan.
- `updateRepaymentTerm(String loanId, String repaymentTerm)`: Updates the repayment term of a loan.
- `listAllLoans()`: Retrieves all loans.
- `calculateRemainingBalance(String loanId)`: Calculates the remaining balance of a loan.
- `makeRepayment(String loanId, BigDecimal repaymentAmount)`: Registers a repayment.
- `applyInterestAccrual(String loanId)`: Applies interest accrual to a loan.
- `notifyUpcomingPayments(String loanId)`: Notifies the borrower of upcoming payments.
- `closeLoan(String loanId)`: Closes a loan.
- `getLoanHistoryForCustomer(String customerId)`: Retrieves loan history for a customer.
- `notifyLatePayment(String loanId)`: Notifies the borrower of a late payment.
- `requestLoanStatement(String loanId)`: Provides a detailed statement of a loan.
- `approveLoanModificationRequest(String loanId, ModificationDetailsDTO modificationDetails)`: Approves a loan modification request.
- `rejectLoanModificationRequest(String loanId, String reason)`: Rejects a loan modification request.
- `reviewLoanDefaultRisk(String loanId)`: Reviews the default risk of a loan.

## Repository Layer

### Interface: LoanRepository

#### Methods:

- `Add(Loan loan)`: Saves a new loan record.
- `GetById(String loanId)`: Finds a loan by its ID.
- `Update(Loan loan)`: Updates a loan record.
- `GetAll()`: Retrieves all loans.

## Endpoints and DTO

#### Methods:

- **POST /loans**

  - Description: Initiates a new loan.
  - Request Body: LoanDTO

- **GET /loans/{loanId}**

  - Description: Retrieves a specific loan by its ID.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}**

  - Description: Updates loan details.
  - Path Parameter: loanId (String)
  - Request Body: LoanDTO

- **GET /loans/{loanId}/repayment-schedule**

  - Description: Retrieves the repayment schedule of a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/repayment-schedule**

  - Description: Updates the repayment schedule of a loan.
  - Path Parameter: loanId (String)
  - Request Body: RepaymentScheduleDTO

- **PUT /loans/{loanId}/remaining-balance**

  - Description: Updates the remaining balance of a loan.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/interest-rate**

  - Description: Updates the interest rate of a loan.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/repayment-term**

  - Description: Updates the repayment term of a loan.
  - Path Parameter: loanId (String)
  - Request Body: String

- **GET /loans**

  - Description: Retrieves all loans.

- **GET /loans/{loanId}/loan-history**

  - Description: Retrieves loan history for a customer.
  - Path Parameter: customerId (String)

- **GET /loans/{loanId}/notify-late-payment**

  - Description: Notifies the borrower of a late payment.
  - Path Parameter: loanId (String)

- **GET /loans/{loanId}/request-loan-statement**

  - Description: Provides a detailed statement of a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/make-repayment**

  - Description: Registers a repayment.
  - Path Parameter: loanId (String)
  - Request Body: BigDecimal

- **PUT /loans/{loanId}/apply-interest-accrual**

  - Description: Applies interest accrual to a loan.
  - Path Parameter: loanId (String)

- **GET /loans/{loanId}/notify-upcoming-payments**

  - Description: Notifies the borrower of upcoming payments.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/close-loan**

  - Description: Closes a loan.
  - Path Parameter: loanId (String)

- **PUT /loans/{loanId}/approve-modification**

  - Description: Approves a loan modification request.
  - Path Parameter: loanId (String)
  - Request Body: ModificationDetailsDTO

- **PUT /loans/{loanId}/reject-modification**

  - Description: Rejects a loan modification request.
  - Path Parameter: loanId (String)
  - Request Body: String

- **GET /loans/{loanId}/review-default-risk**
  - Description: Reviews the default risk of a loan.
  - Path Parameter: loanId (String)

### DTOs

#### LoanDTO

Attributes:

- `loan_id: String`
- `acc_id: String`
- `loan_type: String`
- `loan_type_id: String`
- `loan_amount: BigDecimal`
- `disbursement_date: Date`
- `repayment_term: String`
- `interest_rate: BigDecimal`
- `monthly_installment: BigDecimal`
- `remaining_balance: BigDecimal`
- `repayment_schedule: RepaymentScheduleDTO`
- `initiated_repayments: List<Repayment>`

#### RepaymentScheduleDTO

Attributes:

- `repayment_schedule: String`

#### ModificationDetailsDTO

Attributes:

- `modification_details: String`

### Repayment

**Description**: Represents a repayment made by a customer towards a loan.

**Attributes**:

- `repayment_id`: Unique identifier for the repayment.
- `loan_id`: Unique identifier for the associated loan.
- `repayment_date`: Date when the repayment was made.
- `amount`: Amount of money repaid.
- `remaining_balance`: Remaining balance of the loan after the repayment.
- `payment_method`: Method used for repayment (e.g., bank transfer, cash, cheque).
- `late_fee`: Late Fee charged for missed or delayed payments.

# Repayment Module in Banking System

## Layers

### Controller Layer

**Interface: RepaymentController**

- **Methods**:
  - `recordRepayment(RepaymentDTO repaymentDTO)`: Endpoint for recording a new repayment.
  - `getRepaymentById(String repaymentId)`: Endpoint for retrieving a specific repayment by its ID.
  - `getRepaymentsByLoanId(String loanId)`: Endpoint for retrieving all repayments made towards a specific loan.
  - `getAllRepayments()`: Endpoint for retrieving all repayments.

### Service Layer

**Interface: RepaymentService**

- **Methods**:
  - `submitRepayment(RepaymentDTO repaymentDTO)`: Handles the recording of a new repayment.
  - `findRepaymentById(String repaymentId)`: Retrieves a specific repayment by its ID.
  - `findRepaymentsByLoanId(String loanId)`: Retrieves all repayments made towards a specific loan.
  - `listAllRepayments()`: Retrieves all repayments.

### Repository Layer

**Interface: RepaymentRepository**

- **Methods**:
  - `add(Repayment repayment)`: Saves a new repayment record.
  - `GetById(String repaymentId)`: Finds a repayment by its ID.
  - `GetAll()`: Retrieves all repayments.

## Endpoints and DTO

### Endpoints

- `POST /repayments`: Submits a new repayment.
- `GET /repayments/{repaymentId}`: Retrieves a specific repayment by its ID.
- `GET /repayments/loan/{loanId}`: Retrieves all repayments made towards a specific loan.
- `GET /repayments`: Retrieves all repayments.

### DTO: RepaymentDTO

**Attributes**:

- `repayment_id`: Unique identifier for the repayment.
- `loan_id`: Unique identifier for the associated loan.
- `repayment_date`: Date when the repayment was made.
- `amount`: Amount of money repaid.
- `remaining_balance`: Remaining balance of the loan after the repayment.
- `payment_method`: Method used for repayment (e.g., bank transfer, cash, cheque).
- `late_fee`: Late Fee charged for missed or delayed payments.
