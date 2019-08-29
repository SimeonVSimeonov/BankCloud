using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels.Accounts;
using BankCloud.Models.BindingModels.Orders;
using BankCloud.Models.BindingModels.Products;
using BankCloud.Models.BindingModels.Users;
using BankCloud.Models.ViewModels.Accounts;
using BankCloud.Models.ViewModels.CreditScorings;
using BankCloud.Models.ViewModels.Home;
using BankCloud.Models.ViewModels.Orders;
using BankCloud.Models.ViewModels.Products;
using BankCloud.Models.ViewModels.Users;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankCloud.Web.MappingConfiguration
{
    public class BankCloudProfile : Profile
    {
        public BankCloudProfile()
        {
            CreateMap<Order, AllOrdersViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.GetType().Name.ToString()));

            CreateMap<Product, UsersProductsViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.GetType().Name.ToString()));

            CreateMap<Loan, ProductsLoansViewModel>()
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Account.Currency.IsoCode));

            CreateMap<Save, ProductsSavesViewModel>()
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Account.Currency.IsoCode));

            CreateMap<Loan, ProductsLoanDetailsViewModel>()
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Account.Currency.IsoCode))
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Account.Currency.Name))
                .ForMember(x => x.Seller, y => y.MapFrom(src => src.Account.BankUser.UserName));

            CreateMap<Save, ProductsSaveDetailsViewModel>()
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Account.Currency.IsoCode))
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Account.Currency.Name))
                .ForMember(x => x.Seller, y => y.MapFrom(src => src.Account.BankUser.UserName));

            CreateMap<SellsLoanInputModel, Loan>();

            CreateMap<SellsSaveInputModel, Save>();

            CreateMap<Loan, OrdersOrderLoanInputModel>()
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Account.Currency.Name));

            CreateMap<Save, OrdersOrderSaveInputModel>()
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Account.Currency.Name));

            CreateMap<OrdersOrderLoanInputModel, OrderLoan>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.LoanId, y => y.MapFrom(src => src.Id));

            CreateMap<OrdersOrderSaveInputModel, OrderSave>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.SaveId, y => y.MapFrom(src => src.Id));

            CreateMap<OrderLoan, UsersOrderedLoansViewModel>()
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Loan.Account.Currency.IsoCode))
                .ForMember(x => x.AdUrl, y => y.MapFrom(src => src.Loan.AdUrl));

            CreateMap<OrderSave, UsersOrderedSavesViewModel>()
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Save.Account.Currency.IsoCode))
                .ForMember(x => x.Seller, y => y.MapFrom(src => src.Save.Account.BankUser))
                .ForMember(x => x.AdUrl, y => y.MapFrom(src => src.Save.AdUrl));

            CreateMap<OrderLoan, OrderedLoansDetailViewModel>()
                .ForMember(x => x.Seller, y => y.MapFrom(src => src.Loan.Account.BankUser))
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Loan.Account.Currency.IsoCode))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Loan.Description))
                .ForMember(x => x.Account, y => y.MapFrom(src => src.Account.IBAN + " | " + src.Account.Currency.Name))
                .ForMember(x => x.DueAmount, y => y.MapFrom(src => src.MonthlyFee * src.Period));

            CreateMap<OrderSave, OrderedSavesDetailViewModel>()
                .ForMember(x => x.Seller, y => y.MapFrom(src => src.Save.Account.BankUser))
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Save.Account.Currency.IsoCode))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Save.Description))
                .ForMember(x => x.Account, y => y.MapFrom(src => src.Account.IBAN + " | " + src.Account.Currency.Name))
                .ForMember(x => x.DueAmount, y => y.MapFrom(src => src.MonthlyFee * src.Period));

            CreateMap<Account, UsersAccountViewModel>()
                .ForMember(x => x.IsoCode, y => y.MapFrom(src => src.Currency.IsoCode))
                .ForMember(x => x.PendingRecharges, y => y.MapFrom(src => src.Transfers.Count()))
                .ForMember(x => x.PendingPayments, y => y.MapFrom(src => src.Payments.Count()));

            CreateMap<AccountInputModel, Account>()
                .ForMember(x => x.CurrencyId, y => y.MapFrom(src => src.Currency))
                .ForMember(x => x.Currency, opt => opt.Ignore());

            CreateMap<AccountActivateInputModel, Account>();

            CreateMap<AccountActivateInputModel, Address>();

            CreateMap<AccountActivateInputModel, BankUser>();

            CreateMap<AddressInputModel, Address>();

            CreateMap<Type, UsersProductsPanelViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.Name));

            CreateMap<IEnumerable<string>, UsersProductsPanelViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src));

            CreateMap<Product, IndexViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.GetType().Name));

            CreateMap<Product, HomeCategoriesViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.GetType().Name));

            CreateMap<Product, ProductsLoansViewModel>()
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Account.Currency.IsoCode));

            CreateMap<Product, ProductsLoanDetailsViewModel>();

            CreateMap<Product, ProductsSaveDetailsViewModel>();

            CreateMap<OrderLoan, CreditScoringsOrderedLoansViewModel>()
                .ForMember(x => x.AdUrl, y => y.MapFrom(src => src.Loan.AdUrl))
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Account.Currency.IsoCode));
            CreateMap<OrderSave, CreditScoringsOrderedSavesViewModel>()
                .ForMember(x => x.AdUrl, y => y.MapFrom(src => src.Save.AdUrl))
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Save.Account.Currency.IsoCode));

            CreateMap<OrderLoan, CreditScoringsOrderedLoanDetailViewModel>()
                .ForMember(x => x.Buyer, y => y.MapFrom(src => src.Account.BankUser.UserName))
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Account.Currency.IsoCode))
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Account.Currency.Name))
                .ForMember(x => x.AccountForTransfer, y => y.MapFrom(src => src.Account.IBAN + " | " + src.Account.Currency.IsoCode))
                .ForMember(x => x.BuyerAcconts, y => y.MapFrom(src => src.Account.BankUser.Accounts))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Loan.Description));
            CreateMap<OrderSave, CreditScoringsOrderedSaveDetailViewModel>()
                .ForMember(x => x.Buyer, y => y.MapFrom(src => src.Account.BankUser.UserName))
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Save.Account.Currency.IsoCode))
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Save.Account.Currency.Name))
                .ForMember(x => x.AccountForTransfer, y => y.MapFrom(src => src.Account.IBAN + " | " + src.Account.Currency.IsoCode))
                .ForMember(x => x.BuyerAcconts, y => y.MapFrom(src => src.Account.BankUser.Accounts))
                .ForMember(x => x.Description, y => y.MapFrom(src => src.Save.Description));

            CreateMap<AccountsChargeInputModel, ChargeBankCloudInputModel>();

            CreateMap<ChargeBankCloudInputModel, Transfer>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.AccountId, y => y.MapFrom(src => src.Id));
            //.ForMember(x => x.ForeignAccountId, y => y.MapFrom(src => src.Id));

            //CreateMap<Transfer, TransferBankCloudInputModel>();
            CreateMap<TransferBankCloudInputModel, Transfer>()
                .ForMember(x => x.Id, y => y.Ignore())
                .ForMember(x => x.AccountId, y => y.MapFrom(src => src.Id))
                .ForMember(x => x.ForeignAccountId, y => y.MapFrom(src => src.Id));


            CreateMap<Transfer, TransfersDetailViewModel>()
                .ForMember(x => x.Recipient, y => y.MapFrom(src => src.Account.BankUser.UserName))
                .ForMember(x => x.RecipientIban, y => y.MapFrom(src => src.Account.IBAN));

            CreateMap<Account, AccountsDetailViewModel>()
                .ForMember(x => x.IsoCode, y => y.MapFrom(src => src.Currency.IsoCode))
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Currency.Name));


        }
    }
}
