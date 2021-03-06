﻿using API.Omorfias.Data.Base;
using API.Omorfias.Data.Interfaces;
using API.Omorfias.Data.Models;
using System.Collections.Generic;
using System.Linq;

namespace API.Omorfias.Data.Repositories
{
    public class EnterpriseRepository : IEnterpriseRepository
    {
        private readonly OmorfiasContext _dbContext;
        public EnterpriseRepository(OmorfiasContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<Enterprise> GetBetterRated()
        {
            var enterprises = _dbContext.Enterprise.Where(userDb => (userDb.Evaluation > 0)).ToList();

            return enterprises;
        }

        public Enterprise GetEnterprise(int id)
        {
            var enterprises = new List<Enterprise>
            {
                 new Enterprise{Adress = new Adress{ City ="Belo Horizonte", Id   = 1,Neighborhood="Savassi", Number= 371, Street ="R. Tomé de Souza", Telephone = 31995278569},AverageValue = 4,Category= Enumerator.CategoryEnum.BarberShop, UrlImage="https://omorfias.s3-sa-east-1.amazonaws.com/salao1.png", Cnpj = 58284242000134, Description="Salão e barbearia especializada em cabelos Afro. Quer dar um trato no visual? Invista no seu estilo black e liberte a fera em você!", Evaluation = 4, Id=1, Name="Irmãos Souza", Telephone = 3133352485, ServiceLocation = new ServiceLocation{Id =1, Home =true,Store=true },ReviewsNumber=20},


                new Enterprise{Adress = new Adress{ City ="Belo Horizonte", Id   = 2,Neighborhood="Pampulha", Number= 921, Street ="Av. Cel. José Dias Bicalho", Telephone = 31995854725},AverageValue = 3,Category= Enumerator.CategoryEnum.BeautyStudio, UrlImage= "https://omorfias.s3-sa-east-1.amazonaws.com/salao2.jpg", Cnpj = 58284242000134, Description="Salão e barbearia especializada em cortes de cabelo masculio e feminino, e fornecemos serviços de estética em geral!", Evaluation = 4, Id=2, Name="Tio Zé", Telephone = 3136521452, ServiceLocation = new ServiceLocation{Id =2, Home =true,Store=true },ReviewsNumber=33},


                new Enterprise{Adress = new Adress{ City ="Belo Horizonte", Id   = 3,Neighborhood="Santo Antônio", Number= 82, Street ="R. Barão de Macaúbas", Telephone = 31995854725},AverageValue = 5,Category= Enumerator.CategoryEnum.BarberShop, UrlImage= "https://omorfias.s3-sa-east-1.amazonaws.com/salao3.png", Cnpj = 58284242000134, Description="Salão de cabeleireiros especializados em tingimentos e design de sobrancelha, venha fazer seu dia da noiva conosco!", Evaluation = 4, Id=2, Name="Studio WL - Salão de Beleza", Telephone = 3136521452, ServiceLocation = new ServiceLocation{Id =2, Home =true,Store=true },ReviewsNumber=74},
            };
            var singleEnterprise = enterprises.Where(enterprise => enterprise.Id == id).FirstOrDefault();

            singleEnterprise.Services = new List<Services>
            {
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BarberShop, Title = "Corte e Barba", Id  = 1, Price = 29.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/john-arano-CCTCHXEsan8-unsplash.png", Description="Corte de cabelo e barbaa"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BeautyStudio, Title = "Hidratação Capilar", Id  = 2, Price = 69.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/adam-winger-WDmvpGs2060-unsplash.png", Description="Hidratação capilar completa"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BeautyClinic, Title = "Limpeza de Pele", Id  = 3, Price = 119.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/5+Dicas+Para+Spa+em+Casa+-+Estilo+Pro%E2%95%A0%C3%BCprio+By+Sir+monte+Spa+em+Casa%2C+rotina.png", Description = "Skin Care completa"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.Tattoo, Title = "Furo e Piercing", Id  = 4, Price = 49.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/kilian-seiler-ZMYkPSNrb8I-unsplash.png", Description="Furo com piercing do studio, aço cirúrgico"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BeautyClinic, Title = "Sessão de Massagem", Id  = 5, Price = 149.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/ale-romo-photography-CLiwQXx7kT8-unsplash.png", Description="1 hora de masssagem"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BarberShop, Title = "Corte Infantil", Id  = 6, Price = 25.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/carlos-magno-7tllY5pwe4s-unsplash.png", Description="Corte infantil até 10 anos"}
            };

            return singleEnterprise;
        }

        public List<Enterprise> GetNextToYou()
        {
            var enterprises = new List<Enterprise>
            {
                 new Enterprise{Adress = new Adress{ City ="Belo Horizonte", Id   = 1,Neighborhood="Savassi", Number= 371, Street ="R. Tomé de Souza", Telephone = 31995278569},AverageValue = 4,Category= Enumerator.CategoryEnum.BarberShop, UrlImage="https://omorfias.s3-sa-east-1.amazonaws.com/salao1.png", Cnpj = 58284242000134, Description="Tif's Savassi", Evaluation = 4, Id=1, Name="Irmãos Souza", Telephone = 3133352485, ServiceLocation = new ServiceLocation{Id =1, Home =true,Store=true }},


                new Enterprise{Adress = new Adress{ City ="Belo Horizonte", Id   = 2,Neighborhood="Pampulha", Number= 921, Street ="Av. Cel. José Dias Bicalho", Telephone = 31995854725},AverageValue = 3,Category= Enumerator.CategoryEnum.BeautyStudio, UrlImage= "https://omorfias.s3-sa-east-1.amazonaws.com/salao2.jpg", Cnpj = 58284242000134, Description="Tio Zé", Evaluation = 4, Id=2, Name="Dom Beleza E Estética", Telephone = 3136521452, ServiceLocation = new ServiceLocation{Id =2, Home =true,Store=true }},


                new Enterprise{Adress = new Adress{ City ="Belo Horizonte", Id   = 3,Neighborhood="Santo AntÇonio", Number= 82, Street ="R. Barão de Macaúbas", Telephone = 31995854725},AverageValue = 5,Category= Enumerator.CategoryEnum.BarberShop, UrlImage= "https://omorfias.s3-sa-east-1.amazonaws.com/salao3.png", Cnpj = 58284242000134, Description="Studio WL - Salão de Beleza", Evaluation = 4, Id=2, Name="Studio WL - Salão de Beleza", Telephone = 3136521452, ServiceLocation = new ServiceLocation{Id =2, Home =true,Store=true }},
            };


            return enterprises;
        }

        public List<Services> RecommendedForYou()
        {
            var services = new List<Services>
            {
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BarberShop, Title = "Corte e Barba", Id  = 1, Price = 29.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/john-arano-CCTCHXEsan8-unsplash.png", Description="Corte de cabelo e barbaa"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BeautyStudio, Title = "Hidratação Capilar", Id  = 2, Price = 69.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/adam-winger-WDmvpGs2060-unsplash.png", Description="Hidratação capilar completa"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BeautyClinic, Title = "Limpeza de Pele", Id  = 3, Price = 119.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/5+Dicas+Para+Spa+em+Casa+-+Estilo+Pro%E2%95%A0%C3%BCprio+By+Sir+monte+Spa+em+Casa%2C+rotina.png", Description = "Skin Care completa"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.Tattoo, Title = "Furo e Piercing", Id  = 4, Price = 49.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/kilian-seiler-ZMYkPSNrb8I-unsplash.png", Description="Furo com piercing do studio, aço cirúrgico"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BeautyClinic, Title = "Sessão de Massagem", Id  = 5, Price = 149.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/ale-romo-photography-CLiwQXx7kT8-unsplash.png", Description="1 hora de masssagem"},
                 new Services{ CategoryEnum  =  Enumerator.CategoryEnum.BarberShop, Title = "Corte Infantil", Id  = 6, Price = 25.9M, Url="https://omorfias.s3-sa-east-1.amazonaws.com/assets/assets/carlos-magno-7tllY5pwe4s-unsplash.png", Description="Corte infantil para crianças de até 10 anos"}
            };


            return services;
        }
    }
}
