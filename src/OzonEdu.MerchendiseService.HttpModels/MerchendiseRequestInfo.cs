﻿using CSharpCourse.Core.Lib.Enums;

namespace OzonEdu.MerchendiseService.HttpModels
{
    public class MerchendiseRequestInfo
    {
        public long RequestId { get; init; }
        public MerchType MerchendisePackType { get; init; }
        public RequestStatus RequestStatus { get; init; }
    }
}