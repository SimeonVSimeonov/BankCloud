using AutoMapper;
using BankCloud.Data.Entities;
using BankCloud.Models.BindingModels;
using BankCloud.Models.ViewModels;
using System;

namespace BankCloud.Web.MappingConfiguration
{
    public class BankCloudProfile : Profile
    {
        public BankCloudProfile()
        {
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

            CreateMap<OrdersOrderLoanInputModel, OrderLoan>()
                .ForMember(x => x.Id, opt => opt.Ignore())
                .ForMember(x => x.LoanId, y => y.MapFrom(src => src.Id));

            CreateMap<OrderLoan, UsersOrderedLoansViewModel>()
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Loan.Account.Currency.IsoCode))
                .ForMember(x => x.AdUrl, y => y.MapFrom(src => src.Loan.AdUrl));

            CreateMap<OrderLoan, OrderedLoansDetailViewModel>()
                .ForMember(x => x.Seller, y => y.MapFrom(src => src.Loan.Account.BankUser))
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Loan.Account.Currency.IsoCode));

            CreateMap<Account, UsersAccountViewModel>()
                .ForMember(x => x.IsoCode, y => y.MapFrom(src => src.Currency.IsoCode));

            CreateMap<AccountInputModel, Account>()
                .ForMember(x => x.CurrencyId, y => y.MapFrom(src => src.Currency))
                .ForMember(x => x.Currency, opt => opt.Ignore());

            CreateMap<AccountActivateInputModel, Account>();

            CreateMap<AccountActivateInputModel, Address>();

            CreateMap<AccountActivateInputModel, BankUser>();

            CreateMap<AddressInputModel, Address>();

            CreateMap<Type, UsersProductsPanelViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.Name));

            CreateMap<Product, IndexViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.GetType().Name));

            CreateMap<Product, HomeCategoriesViewModel>()
                .ForMember(x => x.Type, y => y.MapFrom(src => src.GetType().Name));

            CreateMap<Product, ProductsLoansViewModel>()
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Account.Currency.IsoCode));

            CreateMap<Product, ProductsLoanDetailsViewModel>();

            CreateMap<Product, ProductsSaveDetailsViewModel>();

            CreateMap<OrderLoan, CreditScoringsOrderedLoansViewModel>()
                .ForMember(x => x.Currency, y => y.MapFrom(src => src.Account.Currency.IsoCode));

            CreateMap<OrderLoan, CreditScoringsOrderedLoanDetailViewModel>()
                .ForMember(x => x.Buyer, y => y.MapFrom(src => src.Account.BankUser.UserName))
                .ForMember(x => x.CurrencyIso, y => y.MapFrom(src => src.Account.Currency.IsoCode))
                .ForMember(x => x.CurrencyName, y => y.MapFrom(src => src.Account.Currency.Name))
                .ForMember(x => x.AccountForTransfer, y => y.MapFrom(src => src.Account.IBAN + " | " + src.Account.Currency.IsoCode))
                .ForMember(x => x.BuyerAcconts, y => y.MapFrom(src => src.Account.BankUser.Accounts));

        }
    }
}
