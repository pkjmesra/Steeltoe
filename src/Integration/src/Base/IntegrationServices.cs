﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the Apache 2.0 License.
// See the LICENSE file in the project root for more information.

using Microsoft.Extensions.DependencyInjection;
using Steeltoe.Common.Contexts;
using Steeltoe.Common.Converter;
using Steeltoe.Common.Expression;
using Steeltoe.Common.Expression.CSharp;
using Steeltoe.Common.Util;
using Steeltoe.Integration.Support;
using Steeltoe.Integration.Support.Channel;
using Steeltoe.Messaging;
using Steeltoe.Messaging.Core;
using System;

namespace Steeltoe.Integration
{
    public class IntegrationServices : IIntegrationServices
    {
        protected IMessageBuilderFactory _messageBuilderFactory;
        protected IConversionService _conversionService;
        protected IIDGenerator _idGenerator;
        protected IDestinationResolver<IMessageChannel> _channelResolver;
        protected IApplicationContext _context;
        protected IExpressionParser _expressionParser;

        public IntegrationServices(IApplicationContext context)
        {
            _context = context;
        }

        public virtual IMessageBuilderFactory MessageBuilderFactory
        {
            get
            {
                if (_messageBuilderFactory == null)
                {
                    _messageBuilderFactory = _context?.GetService<IMessageBuilderFactory>();
                    if (_messageBuilderFactory == null)
                    {
                        _messageBuilderFactory = new DefaultMessageBuilderFactory();
                    }
                }

                return _messageBuilderFactory;
            }

            set
            {
                _messageBuilderFactory = value;
            }
        }

        public virtual IExpressionParser ExpressionParser
        {
            get
            {
                if (_expressionParser == null)
                {
                    _expressionParser = _context?.GetService<IExpressionParser>();
                    if (_expressionParser == null)
                    {
                        _expressionParser = new ExpressionParser();
                    }
                }

                return _expressionParser;
            }

            set
            {
                _expressionParser = value;
            }
        }

        public virtual IDestinationResolver<IMessageChannel> ChannelResolver
        {
            get
            {
                if (_channelResolver == null)
                {
                    _channelResolver = _context?.GetService<IDestinationResolver<IMessageChannel>>();
                    if (_channelResolver == null)
                    {
                        _channelResolver = new DefaultMessageChannelResolver(_context);
                    }
                }

                return _channelResolver;
            }

            set
            {
                _channelResolver = value;
            }
        }

        public virtual IConversionService ConversionService
        {
            get
            {
                if (_conversionService == null)
                {
                    _conversionService = _context?.GetService<IConversionService>();
                    if (_conversionService == null)
                    {
                        _conversionService = DefaultConversionService.Singleton;
                    }
                }

                return _conversionService;
            }

            set
            {
                _conversionService = value;
            }
        }

        public virtual IIDGenerator IdGenerator
        {
            get
            {
                if (_idGenerator == null)
                {
                    _idGenerator = _context?.GetService<IIDGenerator>();
                    if (_idGenerator == null)
                    {
                        _idGenerator = new DefaultIdGenerator();
                    }
                }

                return _idGenerator;
            }

            set
            {
                _idGenerator = value;
            }
        }
    }
}
