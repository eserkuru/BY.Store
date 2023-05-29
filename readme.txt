** Uygulamada varsayılan olarak müşteri kimlik değeri (CustomerId) olarak "1" ayarlanmıştır.
** /api/Customers/ShowCurrentCustomer endpointi kullanılarak mevcut CustomerId sorgulanabilir.
** Müşteri değiştirmek için;
    /api/Customers/ChangeCustomerUsingId?id endpointine rastgele bir pozitif tam sayı yazarak 
    müşteri değiştirilebilirsiniz.

1. Sistemde bulunan ürünler.

    new List<Product>
    {
        new Product{ Id=1, Name = "Pantolon", Price = 499.99 },
        new Product{ Id=2, Name = "Ceket", Price = 1299.99 },
        new Product{ Id=3, Name = "Mont", Price = 3899.99 },
    }

2. Sistemde bulunan ürünlerin stok durumu.

    new List<Stock>
    {
        new Stock{ Id=1, ProductId = 1, Quantity = 10},
        new Stock{ Id=2, ProductId = 2, Quantity = 6},
        new Stock{ Id=3, ProductId = 3, Quantity = 3},
    }