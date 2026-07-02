public class CustomerServiceImpl implements CustomerService {

    private CustomerRepository repository;

    // Dependency Injection through Constructor
    public CustomerServiceImpl(CustomerRepository repository) {
        this.repository = repository;
    }

    @Override
    public void displayCustomer() {
        System.out.println(repository.findCustomer());
    }

}