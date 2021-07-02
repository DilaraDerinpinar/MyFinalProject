using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using Core.Entities;


namespace Core.DataAccess
{
    //generic constraint
    //class:referans tip
    //IEntity : IEntity olabilir veya onu implemente eden nesne/referans tip olabilir.
    //new():new lenebilir olmalı.
    public interface IEntityRepository<T> where T:class,IEntity,new()
    {
        //BURADA GENERICLERLE CALISTIK CUNKU ICATEGORYDALDA DA IPRODUCTDALDA DA ICUSTOMERDALDA DA HEP AYNI METOTLAR OLUYORDU. BU TEKRARI ONLEMEK ICIN DAHA GENEL BIR IFADE OLACAK SEKILDE IENTITYREPOSITORY INTERFACE I ILE CALISICAZ
        List<T> GetAll(Expression<Func<T,bool>> filter=null); //FİLTER=NULL IN ANLAMI FİLTRE VERMEYEBİLİRSİN DE VEREBİLİLRSİN DE ANLAMINDA SUREKLİ GETBYID METODLARI FELAN GEREKMİYOR BÖYLE OLDUĞU İÇİN

        T Get(Expression<Func<T, bool>> filter); //burada kesinlikle filtre verilcek
        void Add(T entity);

        void Update(T entity);


        void Delete(T entity);

        //EXPRESSION FILTRELEMEYI SAGLAR.
    }
}
