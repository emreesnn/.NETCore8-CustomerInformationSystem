using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mbs.Application.Middlewares.Exceptions
{
    public class BaseException<T>
    {
        public Task DataMustNotBeNull(T data, string? message = "")
        {
            if (data == null) throw new NotFoundException($"{message} Bu veri silinmiş veya veritabanında bulunmuyor olabilir.");
            return Task.CompletedTask;
        }
        public Task DataListMustNotBeNull(IList<T> data, string? message = "")
        {
            if (data == null) throw new NotFoundException($"{message} Bu veriler silinmiş veya veritabanında bulunmuyor olabilir.");
            return Task.CompletedTask;
        }
    }
}
