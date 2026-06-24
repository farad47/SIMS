using SIMS.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SIMS.Core
{
    public class Product : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; private set; }
        [MaxLength(50)]
        public string? Description { get; private set; }
        public decimal Price { get; private set; }
        public CurrencyType Currency { get; private set; }
        public int Stock { get; private set; }
        private bool IsActive { get; set; }

        public bool IsAvailable => IsActive && Stock > 0;


        public Product(
            string name,
            string description,
            decimal price,
            CurrencyType currency,
            int stock)
        {
            SetName(name);
            SetDescription(description);
            SetPrice(price);
            SetCurrency(currency);
            SetStock(stock);

            IsActive = true;
        }

        public void ChangeName(string name)
        {
            SetName(name);
        }

        public void ChangeDescription(string description)
        {
            SetDescription(description);
        }

        public void ChangePrice(decimal price)
        {
            SetPrice(price);
        }

        public void IncreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0.");

            Stock += quantity;
        }

        public void DecreaseStock(int quantity)
        {
            if (quantity <= 0)
                throw new ArgumentOutOfRangeException(nameof(quantity), "Quantity must be greater than 0.");

            if (Stock < quantity)
                throw new InvalidOperationException("Insufficient stock.");

            Stock -= quantity;
        }

        public void Activate()
        {
            IsActive = true;
        }

        public void Deactivate()
        {
            IsActive = false;
        }

        private void SetName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Product name is required.", nameof(name));

            if (name.Length > 50)
                throw new ArgumentException("Product name cannot be longer than 50 characters.", nameof(name));

            Name = name;
        }

        private void SetDescription(string description)
        {
            if (description.Length > 50)
                throw new ArgumentException("Product description cannot be longer than 50 characters.", nameof(description));

            Description = description;
        }

        private void SetPrice(decimal price)
        {
            if (price <= 0)
                throw new ArgumentOutOfRangeException(nameof(price), "Price must be greater than 0.");

            Price = price;
        }

        private void SetCurrency(CurrencyType currency)
        {
            if (currency == CurrencyType.Unknown)
                throw new ArgumentException("Currency is required.", nameof(currency));

            Currency = currency;
        }

        private void SetStock(int stock)
        {
            if (stock < 0)
                throw new ArgumentOutOfRangeException(nameof(stock), "Stock cannot be less than 0.");

            Stock = stock;
        }
    }
}
