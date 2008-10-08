﻿//-----------------------------------------------------------------------
// <copyright file="MessageReceivingEndpoint.cs" company="Andrew Arnott">
//     Copyright (c) Andrew Arnott. All rights reserved.
// </copyright>
//-----------------------------------------------------------------------

namespace DotNetOAuth.Messaging {
	using System;
	using System.Diagnostics;

	/// <summary>
	/// An immutable description of a URL that receives messages.
	/// </summary>
	[DebuggerDisplay("{AllowedMethods} {Location}")]
	public class MessageReceivingEndpoint {
		/// <summary>
		/// Initializes a new instance of the <see cref="MessageReceivingEndpoint"/> class.
		/// </summary>
		/// <param name="locationUri">The URL of this endpoint.</param>
		/// <param name="method">The HTTP method(s) allowed.</param>
		public MessageReceivingEndpoint(string locationUri, HttpDeliveryMethod method)
			: this(new Uri(locationUri), method) { }

		/// <summary>
		/// Initializes a new instance of the <see cref="MessageReceivingEndpoint"/> class.
		/// </summary>
		/// <param name="location">The URL of this endpoint.</param>
		/// <param name="method">The HTTP method(s) allowed.</param>
		public MessageReceivingEndpoint(Uri location, HttpDeliveryMethod method) {
			if (location == null) {
				throw new ArgumentNullException("location");
			}
			if (method == HttpDeliveryMethod.None) {
				throw new ArgumentOutOfRangeException("method");
			}
			if ((method & (HttpDeliveryMethod.PostRequest | HttpDeliveryMethod.GetRequest)) == 0) {
				throw new ArgumentOutOfRangeException("method", MessagingStrings.GetOrPostFlagsRequired);
			}

			this.Location = location;
			this.AllowedMethods = method;
		}

		/// <summary>
		/// Gets the URL of this endpoint.
		/// </summary>
		public Uri Location { get; private set; }

		/// <summary>
		/// Gets the HTTP method(s) allowed.
		/// </summary>
		public HttpDeliveryMethod AllowedMethods { get; private set; }
	}
}