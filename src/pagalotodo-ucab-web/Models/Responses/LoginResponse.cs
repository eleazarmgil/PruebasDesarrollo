﻿namespace UCABPagaloTodoWeb.Models.Responses
{
    public class LoginResponse
    {
        public string? operationId { get; set; }
        public string? operationName { get; set; }
        public LoginDataModel[]? data { get; set; }
    }
}