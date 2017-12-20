﻿using System;
namespace VirtualEvent
{

	public class ApiResponse<T> where T : class
	{
		public bool IsSuccess { get; set; }
		public string Status { get; set; }
		public string Message { get; set; }
		public T Result { get; set; }
	}
}
