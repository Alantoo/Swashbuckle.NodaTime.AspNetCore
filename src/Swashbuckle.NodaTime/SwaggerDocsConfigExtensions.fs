﻿namespace Swashbuckle.NodaTime

open System
open System.Runtime.CompilerServices

open Swashbuckle.AspNetCore.SwaggerGen

open NodaTime

open Newtonsoft.Json

open Schemas

[<AutoOpen>]
[<Extension>]
module SwaggerDocsConfigExtensions =

    [<Extension>]
    let ConfigureForNodaTime (config: SwaggerGenOptions, serializerSettings: JsonSerializerSettings) =
        let schemas =
            serializerSettings
            |> Schemas.Create

        config.MapType<Instant>(fun () -> schemas.Instant)
        config.MapType<LocalDate>(fun () -> schemas.LocalDate)
        config.MapType<LocalTime>(fun () -> schemas.LocalTime)
        config.MapType<LocalDateTime>(fun () -> schemas.LocalDateTime)
        config.MapType<OffsetDateTime>(fun () -> schemas.OffsetDateTime)
        config.MapType<ZonedDateTime>(fun () -> schemas.ZonedDateTime)
        config.MapType<Interval>(fun () -> schemas.Interval)
        config.MapType<Offset>(fun () -> schemas.Offset)
        config.MapType<Period>(fun () -> schemas.Period)
        config.MapType<Duration>(fun () -> schemas.Duration)
        config.MapType<DateTimeZone>(fun () -> schemas.DateTimeZone)

        config.MapType<Nullable<Instant>>(fun () -> schemas.Instant)
        config.MapType<Nullable<LocalDate>>(fun () -> schemas.LocalDate)
        config.MapType<Nullable<LocalTime>>(fun () -> schemas.LocalTime)
        config.MapType<Nullable<LocalDateTime>>(fun () -> schemas.LocalDateTime)
        config.MapType<Nullable<OffsetDateTime>>(fun () -> schemas.OffsetDateTime)
        config.MapType<Nullable<ZonedDateTime>>(fun () -> schemas.ZonedDateTime)
        config.MapType<Nullable<Interval>>(fun () -> schemas.Interval)
        config.MapType<Nullable<Offset>>(fun () -> schemas.Offset)
        config.MapType<Nullable<Duration>>(fun () -> schemas.Duration)

    type SwaggerGenOptions with
        member this.ConfigureForNodaTime(serializerSettings: JsonSerializerSettings) =
            ConfigureForNodaTime(this, serializerSettings)
        member this.ConfigureForNodaTime =
            ConfigureForNodaTime(this, JsonConvert.DefaultSettings.Invoke())
