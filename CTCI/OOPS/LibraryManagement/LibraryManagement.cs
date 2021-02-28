using System;
using System.Collections.Generic;
using System.Text;

namespace CTCI.OOPS.LibraryManagement
{
    /*
     ****************** Scope************************
     *1. Three Main Actors
     *      1. Librarian   - Add and modify book, user and book item. Also checkout, check in and reserv book
     *      2. Member/USer - Search, checkout, reserve, renew and return book
     *      3. System - Send notifications 
     *
     *1. User/Profile/Membership Managment 
     *  ---Users Entity-----
     *      UserId
     *      FirstName
     *      LastName 
     *      MembershipNumber
     *      NoofBooksCheckedout
     *      
     *      - Add User
     *      - Delete User
     *      - Edit User
     *      - Search User
     *      
     *2. Books Management 
     *      --Book Entity---
     *          BookId
     *          Title
     *          Author
     *          PublicationDate
     *          Category
     *          NoOfCopies
     *          Location
     *          
     *      - Add Book
     *      - Delete Book
     *      - Edit Book
     *      - Search Books : By title, author, publication_date, subject_category
     *      
     *          
     *3. Transactions 
     *      - Checkout Books
     *      - Check in Books
     *      - Request for Book 
     *      - Renew
     *      - Users and checkedout books
     *      - DueDate 
     *      
     *3. DVD Management 
     *    - Add DVD
     *    - Delete DVD
     *    - Edit DVD
     *    
     *4. Collect Fine
     *      --UserID
     *      --Amount
     *      --Fine
     *      
     * 5. Notifications
     *      --When book is available
     *      --Due date reminder
     *      
     * 5. Configurations
     *      1. No of days user can checkout the books
     *      2. No of books user can checkout 
     */
    class LibraryManagement
    {

    }

    //Step 1 : Create Enums and Constant
    public enum BookFormat
    {
        HardCover,
        PaperCover,
        EBook,
        AudioBook,
        Magazine,
        Journal,
        NewsPaper

    }

    public enum BookStatus
    {
        Available,
        Reserved,
        Loaned,
        Lost
    }

    public enum ReservationStatus
    {
        Waiting,
        Pending,
        Cancelled,
        None
    }


    public class Address
    {
        private string Name;
        private string StreetAddress;
        private string City;
        private string County;
        private string State;
        private string Zip;
        private string Country;

    }

    public class Person
    {
        private String name;
        private Address address;
        private String email;
        private String phone;
    }

    public class Constant 
    {
        public const int MAX_BOOKS_ISSUED_TO_A_USER = 5;
        public const int MAX_LENDING_DAYS = 10;
    }
    public enum AccountStatus
    {
        Active,
        Close,
        Cancelled,
        Blacklisted,
        None
    }
   
}
