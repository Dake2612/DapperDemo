using System;
namespace DapperDemo.Application.Interfaces
{
	public interface IUnitOfWork
	{
		IUserRepository User { get; set; }

	}
}

