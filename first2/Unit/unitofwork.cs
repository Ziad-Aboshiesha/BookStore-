using first2.Models;

namespace first2.Unit
{
    public class unitofwork
    {
        BookStoreContext db;
        generalrepo<Book> books;
        generalrepo<Author> authors;
        generalrepo<Order> orders;

        generalrepo<Order_details> order_details;

        generalrepo<Admin> admins;
        generalrepo<Customer> customers;
        generalrepo<Category> categories;
        public unitofwork(BookStoreContext db)
        {
            this.db = db;
        }
        public generalrepo<Book>Books 
        { 
            get 
            { if (books == null)
                    books = new generalrepo<Book>(db);
                return books;
            }
        }
        public generalrepo<Author> Authors 
        {
            get
            {
                if (authors == null)
                    authors = new generalrepo<Author>(db);
                return authors;
            }
        }
        public generalrepo<Admin> Admins
        {
            get
            {
                if (admins == null)
                    admins = new generalrepo<Admin>(db);
                return admins;
            }
        }
        public generalrepo<Customer> Customers
        {
            get
            {
                if (customers == null)
                    customers = new generalrepo<Customer>(db);
                return customers;
            }
        }
        public generalrepo<Category> Categories
        {
            get
            {
                if (categories == null)
                    categories = new generalrepo<Category>(db);
                return categories;
            }
        }
        public generalrepo<Order> Orders
        {
            get
            {
                if (orders == null)
                    orders = new generalrepo<Order>(db);
                return orders;
            }
        }
        public generalrepo<Order_details> Order_details
        {
            get
            {
                if (order_details == null)
                    order_details = new generalrepo<Order_details>(db);
                return order_details;
            }
        }
    }
}
