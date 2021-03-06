﻿//
//  PolygonFeature.cs
//
//  Author:
//       Emmanuel Mathot <emmanuel.mathot@terradue.com>
//
//  Copyright (c) 2014 Terradue
//
//  Adapted from GeoJSON.Net / https://github.com/jbattermann/GeoJSON.Net
//      Copyright (c) Jörg Battermann 2011

namespace Terradue.GeoJson.Feature {
    using System.Collections.Generic;
    using Terradue.GeoJson.Geometry;
    using System.Runtime.Serialization;
    using System;
    using ServiceStack.Text;

    /// <summary>
    /// A GeoJSON <see cref="http://geojson.org/geojson-spec.html#feature-objects">Feature Object</see>.
    /// </summary>
    [DataContract]
    public class PolygonFeature : Feature {
        /// <summary>
        /// Initializes a new instance of the <see cref="Feature"/> class.
        /// </summary>
        /// <param name="geometry">The Geometry Object.</param>
        /// <param name="properties">The properties.</param>
        public PolygonFeature(Polygon geometry, Dictionary<string, object> properties) : base(geometry, properties) {
            Geometry = geometry;
        }

        /// <summary>
        /// Create a feature from a json string.
        /// </summary>
        /// <returns>The json.</returns>
        /// <param name="json">Json.</param>
        public new static PolygonFeature ParseJson(string json) {

            Polygon geometry = new Polygon();
            var mpObj = JsonObject.Parse(json);

            geometry = mpObj.JsonTo<Polygon>("geometry");

            PolygonFeature mp = new PolygonFeature(geometry, mpObj.JsonTo<Dictionary<string, object>>("properties"));
            mp.Id = mpObj.JsonTo<string>("id");
            return mp;

        }

        /// <summary>
        /// Gets or sets the geometry.
        /// </summary>
        /// <value>
        /// The geometry.
        /// </value>
        //[JsonConverter(typeof(GeometryConverter))]
        [DataMember(Name = "geometry")]
        public new Polygon Geometry { get; set; }
    }
}
