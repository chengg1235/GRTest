using Niusys.WebAPI.Common.Filters;
using Niusys.WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Niusys.WebAPI.Controllers
{
    [RoutePrefix("api/products"), SessionValidate]
    public class ProductController : ApiController
    {
        [HttpGet]
        public void ProductsAPI()
        {
        }

        /// <summary>
        /// 产品分页数据获取
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("product/getList")]
        public Page<Product> GetProductList(string sessionKey)
        {
            return new Page<Product>();
        }

        /// <summary>
        /// 获取单个产品
        /// </summary>
        /// <param name="productId"></param>
        /// <returns></returns>
        [HttpGet, Route("product/get")]
        public Product GetProduct(string sessionKey, Guid productId)
        {
            return new Product() { ProductId = productId };
        }

        /// <summary>
        /// 添加产品
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost, Route("product/add")]
        public Guid AddProduct(string sessionKey, Product product)
        {
            return Guid.NewGuid();
        }

        /// <summary>
        /// 更新产品
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="product"></param>
        [HttpPost, Route("product/update")]
        public void UpdateProduct(string sessionKey, Guid productId, Product product)
        {

        }

        /// <summary>
        /// 删除产品
        /// </summary>
        /// <param name="productId"></param>
        [HttpDelete, Route("product/delete")]
        public void DeleteProduct(string sessionKey, Guid productId)
        {

        }
    }
}
