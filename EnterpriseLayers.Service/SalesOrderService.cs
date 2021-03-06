﻿using EnterpriseLayers.Contract.DataAccess;
using EnterpriseLayers.Contract.Repository;
using EnterpriseLayers.Contract.Service;
using EnterpriseLayers.Model.Domain;
using EnterpriseLayers.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnterpriseLayers.Service {
	public class SalesOrderService : UnitOfWorkService, ISalesOrderService {
		private IRepository<SalesOrderHeader> _salesOrderHeaderRepository;
		private IRepository<SalesOrderDetail> _salesOrderDetailRepository;

		public SalesOrderService(IUnitOfWork uow) : base(uow) {
			_salesOrderHeaderRepository = new GenericRepository<SalesOrderHeader>(uow);
			_salesOrderDetailRepository = new GenericRepository<SalesOrderDetail>(uow);
		}
	}
}
