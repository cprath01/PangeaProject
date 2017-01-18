using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RabbitMQConsumerService.Interfaces;
using Domain.DAL.Interfaces;
using Domain.Converters.Interfaces;
using ReposAPIService;
using MQConsumerService.Domain;

namespace RabbitMQConsumerService
{
    public class MessageProcessor : IMessageProcessor
    {
        private IReposAPI _api;
        private ILoadDataRequestConverter _converter;
        private IRepoDAL_Save _dal;

        public MessageProcessor(IRepoDAL_Save dal, IReposAPI api, ILoadDataRequestConverter converter)
        {
            _converter = converter;
            _api = api;
            _dal = dal;
        }
        public async void ProcessMessage(string message)
        {
            var request = _converter.Convert(message);

            switch (request.Header.Request_Type)
            {
                case Domain.Common.Enums.RequestType.Load:
                    List<Repos> list;
                    if (request.Payload.ToLower() == "all")
                        list = await _api.Get();
                    else
                        list = await _api.Get(request.Payload);

                    _dal.Save(list);
                    break;
                default:
                    throw new Exception("Invalid Message Type");
            }
        }
    }
}
