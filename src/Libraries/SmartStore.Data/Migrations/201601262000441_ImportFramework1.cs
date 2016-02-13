namespace SmartStore.Data.Migrations
{
	using System.Data.Entity.Migrations;
	using Setup;

	public partial class ImportFramework1 : DbMigration, ILocaleResourcesProvider, IDataSeeder<SmartObjectContext>
	{
        public override void Up()
        {
            AddColumn("dbo.ImportProfile", "UpdateOnly", c => c.Boolean(nullable: false));
            AddColumn("dbo.ImportProfile", "KeyFieldNames", c => c.String(maxLength: 1000));
            AddColumn("dbo.ImportProfile", "ResultInfo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ImportProfile", "ResultInfo");
            DropColumn("dbo.ImportProfile", "KeyFieldNames");
            DropColumn("dbo.ImportProfile", "UpdateOnly");
        }

		public bool RollbackOnFailure
		{
			get { return false; }
		}

		public void Seed(SmartObjectContext context)
		{
			context.MigrateLocaleResources(MigrateLocaleResources);
		}

		public void MigrateLocaleResources(LocaleResourcesBuilder builder)
		{
			builder.AddOrUpdate("Admin.DataExchange.Import.MultipleFilesSameFileTypeNote",
				"For multiple import files please make sure that they are of the same file type and that the content follows the same pattern (e.g. same column headings).",
				"Bei mehreren Importdateien ist darauf zu achten, dass diese vom selben Dateityp sind und deren Inhalt demselben Schema folgt (z.B. gleiche Spalten�berschriften).");

			builder.AddOrUpdate("Admin.DataExchange.Import.ProfileEntitySelectNote",
				"Please select an object that you want to import.",
				"W�hlen Sie bitte ein Objekt aus, das Sie importieren m�chten.");

			builder.AddOrUpdate("Admin.DataExchange.Import.ProfileCreationNote",
				"Please upload an import file, enter a meaningful name for the import profile and save.",
				"Laden Sie bitte eine Importdatei hoch, legen Sie einen aussagekr�ftigen Namen f�r das Importprofil fest und speichern Sie.");

			builder.AddOrUpdate("Admin.DataExchange.Import.AddAnotherFile",
				"Add import file...",
				"Importdatei hinzuf�gen...");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.RunNow.Success.DataImportTask",
				"The task is now running in the background. You will receive an email as soon as it is completed. The progress can be tracked in the import profile list.",
				"Die Aufgabe wird jetzt im Hintergrund ausgef�hrt. Sie erhalten eine E-Mail, sobald sie abgeschlossen ist. Den Fortschritt k�nnen Sie in der Importprofilliste verfolgen.");

			builder.AddOrUpdate("Admin.System.ScheduleTasks.RunNow.Success.DataExportTask",
				"The task is now running in the background. You will receive an email as soon as it is completed. The progress can be tracked in the export profile list.",
				"Die Aufgabe wird jetzt im Hintergrund ausgef�hrt. Sie erhalten eine E-Mail, sobald sie abgeschlossen ist. Den Fortschritt k�nnen Sie in der Exportprofilliste verfolgen.");

			builder.AddOrUpdate("Admin.DataExchange.Import.DefaultProfileNames",
				"My product import;My category import;My customer import;My newsletter subscription import",
				"Mein Produktimport;Mein Warengruppenimport;Mein Kundenimport;Mein Newsletter-Abonnement-Import");

			builder.AddOrUpdate("Admin.DataExchange.Import.LastImportResult",
				"Last import result",
				"Letztes Importergebnis");

			builder.AddOrUpdate("Admin.Common.TotalRows", "Total rows", "Zeilen insgesamt");
			builder.AddOrUpdate("Admin.Common.Skipped", "Skipped", "Ausgelassen");
			builder.AddOrUpdate("Admin.Common.NewRecords", "New records", "Neue Datens�tze");
			builder.AddOrUpdate("Admin.Common.Updated", "Updated", "Aktualisiert");
			builder.AddOrUpdate("Admin.Common.Warnings", "Warnings", "Warnungen");
			builder.AddOrUpdate("Admin.Common.Errors", "Errors", "Fehler");

			builder.AddOrUpdate("Admin.DataExchange.Import.CompletedEmail.Body",
				"This is an automatic notification of store \"{0}\" about a recent data import. Summary:",
				"Dies ist eine automatische Benachrichtung von Shop \"{0}\" �ber einen erfolgten Datenimport. Zusammenfassung:");

			builder.AddOrUpdate("Admin.DataExchange.Import.CompletedEmail.Subject",
				"Import of \"{0}\" has been finished",
				"Import von \"{0}\" ist abgeschlossen");

			builder.AddOrUpdate("Admin.DataExchange.Import.ColumnMapping",
				"Assignment of import fields",
				"Zuordnung der Importfelder");

			builder.AddOrUpdate("Admin.DataExchange.Import.SelectTargetProperty",
				"Create new assignment here",
				"Hier neue Zuordnung vornehmen");

			builder.AddOrUpdate("Admin.DataExchange.Import.UpdateOnly",
				"Only update",
				"Nur aktualisieren",
				"If this option is enabled, only existing data is updated but no new records are added.",
				"Ist diese Option aktiviert, werden nur vorhandene Daten aktualisiert, aber keine neue Datens�tze hinzugef�gt.");

			builder.AddOrUpdate("Admin.DataExchange.Import.KeyFieldNames",
				"Key fields",
				"Schl�sselfelder",
				"Existing records can be identified for updates on the basis of key fields. The key fields are processed in the order how they are defined here.",
				"Anhand von Schl�sselfeldern k�nnen vorhandene Datens�tze zwecks Aktualisierung identifiziert werden. Die Schl�sselfelder werden in der hier festgelegten Reihenfolge verarbeitet.");

			builder.AddOrUpdate("Admin.DataExchange.Import.Validate.OneKeyFieldRequired",
				"At least one key field is required.",
				"Es ist mindestens ein Schl�sselfeld erforderlich.");

			builder.AddOrUpdate("Admin.DataExchange.ColumnMapping.Validate.MultipleMappedIgnored",
				"The following object properties were multiple assigned and thus ignored: {0}",
				"Die folgenden Objekteigenschaft wurden mehrfach zugeodnet und deshalb ignoriert: {0}");

			builder.AddOrUpdate("Admin.DataExchange.ColumnMapping.Validate.MappingsReset",
				"The stored field assignments are invalid due to the change of the delimiter and were reset.",
				"Die gespeicherten Feldzuordnungen sind aufgrund der �nderung des Trennzeichens ung�ltig und wurden zur�ckgesetzt.");


			builder.AddOrUpdate("Common.Download.NoDataAvailable",
				"Download data is not available anymore.",
				"Es sind keine Daten zum Herunterladen mehr verf�gbar.");

			builder.AddOrUpdate("Common.Download.NotAvailable",
				"Download is not available any more.",
				"Der Download ist nicht mehr verf�gbar.");

			builder.AddOrUpdate("Common.Download.SampleNotAvailable",
				"Sample download is not available anymore.",
				"Der Download einer Beispieldatei ist nicht mehr verf�gbar.");

			builder.AddOrUpdate("Common.Download.HasNoSample",
				"The product variant doesn't have a sample download.",
				"F�r die Produktvariante ist der Download einer Beispieldatei nicht verf�gbar.");

			builder.AddOrUpdate("Common.Download.NotAllowed",
				"Downloads are not allowed.",
				"Downloads sind nicht gestattet.");

			builder.AddOrUpdate("Common.Download.MaxNumberReached",
				"You have reached the maximum number of downloads {0}.",
				"Sie haben die maximale Anzahl an Downloads {0} erreicht.");

			builder.AddOrUpdate("Account.CustomerOrders.NotYourOrder",
				"This is not your order.",
				"Dieser Auftrag konnte Ihnen nicht zugeordnet werden.");

			builder.AddOrUpdate("Shipping.CouldNotLoadMethod",
				"The shipping rate computation method could not be loaded.",
				"Die Berechnungsmethode f�r Versandkosten konnte nicht geladen werden.");

			builder.AddOrUpdate("Shipping.OneActiveMethodProviderRequired",
				"At least one shipping rate computation method provider is required to be active.",
				"Mindestens ein Provider zur Berechnung von Versandkosten muss aktiviert sein.");

			builder.AddOrUpdate("Payment.CouldNotLoadMethod",
				"The payment method could not be loaded.",
				"Die Zahlungsart konnte nicht geladen werden.");

			builder.AddOrUpdate("Payment.MethodNotAvailable",
				"The payment method is not available.",
				"Die Zahlungsart steht nicht zur Verf�gung.");

			builder.AddOrUpdate("Payment.OneActiveMethodProviderRequired",
				"At least one payment method provider is required to be active.",
				"Mindestens ein Zahlungsart-Provider muss aktiviert sein.");

			builder.AddOrUpdate("Payment.RecurringPaymentNotSupported",
				"Recurring payments are not supported by selected payment method.",
				"Wiederkehrende Zahlungen sind f�r die gew�hlte Zahlungsart nicht m�glich.");

			builder.AddOrUpdate("Payment.RecurringPaymentNotActive",
				"Recurring payment is not active.",
				"Wiederkehrende Zahlung ist inaktiv.");

			builder.AddOrUpdate("Payment.RecurringPaymentTypeUnknown",
				"The recurring payment type is not supported.",
				"Der Typ von wiederkehrender Zahlung wird nicht unterst�tzt.");

			builder.AddOrUpdate("Payment.CannotCalculateNextPaymentDate",
				"The next payment date could not be calculated.",
				"Das Datum der n�chsten Zahlung kann nicht ermittelt werden.");

			builder.AddOrUpdate("Payment.PayingFailed",
				"Unfortunately we can not handle this purchasing via your preferred payment method. Please select an alternate payment option to complete your order.",
				"Leider k�nnen wir diesen Einkauf nicht �ber die gew�nschte Zahlungsart abwickeln. Bitte w�hlen Sie eine alternative Zahlungsoption aus, um Ihre Bestellung abzuschlie�en.");

			builder.AddOrUpdate("Order.InitialOrderDoesNotExistForRecurringPayment",
				"No initial order exists for the recurring payment.",
				"F�r die wiederkehrende Zahlung existiert kein Ausgangsauftrag.");

			builder.AddOrUpdate("Order.CannotCalculateShippingTotal",
				"The shipping total could not be calculated.",
				"Die Versandkosten konnten nicht berechnet werden.");

			builder.AddOrUpdate("Order.CannotCalculateOrderTotal",
				"The order total could not be calculated.",
				"Die Auftragssumme konnte nicht berechnet werden.");

			builder.AddOrUpdate("Order.BillingAddressMissing",
				"The billing address is missing.",
				"Die Rechnungsanschrift fehlt.");

			builder.AddOrUpdate("Order.ShippingAddressMissing",
				"The shipping address is missing.",
				"Die Lieferanschrift fehlt.");

			builder.AddOrUpdate("Order.CountryNotAllowedForBilling",
				"The country '{0}' is not allowed for billing.",
				"Eine Rechnungslegung ist f�r das Land '{0}' unzul�ssig.");

			builder.AddOrUpdate("Order.CountryNotAllowedForShipping",
				"The country '{0}' is not allowed for shipping.",
				"Ein Versand ist f�r das Land '{0}' unzul�ssig.");

			builder.AddOrUpdate("Order.NoRecurringProducts",
				"There are no recurring products.",
				"Keine wiederkehrenden Produkte.");

			builder.AddOrUpdate("Order.NotFound",
				"The order {0} was not found.",
				"Der Auftrag {0} wurde nicht gefunden.");

			builder.AddOrUpdate("Order.CannotCancel",
				"Cannot cancel order.",
				"Der Auftrag kann nicht storniert werden.");

			builder.AddOrUpdate("Order.CannotMarkCompleted",
				"Cannot mark order as completed.",
				"Der Auftrag kann nicht als abgeschlossen markiert werden.");

			builder.AddOrUpdate("Order.CannotCapture",
				"Cannot capture order.",
				"Der Auftrag kann nicht gebucht werden.");

			builder.AddOrUpdate("Order.CannotMarkPaid",
				"Cannot mark order as paid.",
				"Der Auftrag kann nicht als bezahlt markiert werden.");

			builder.AddOrUpdate("Order.CannotRefund",
				"Cannot do refund for order.",
				"Eine R�ckerstattung ist f�r diesen Auftrag nicht m�glich.");

			builder.AddOrUpdate("Order.CannotPartialRefund",
				"Cannot do partial refund for order.",
				"Eine Teilr�ckerstattung ist f�r diesen Auftrag nicht m�glich.");

			builder.AddOrUpdate("Order.CannotVoid",
				"Cannot do void for order.",
				"Eine Stornierung dieses Auftrages ist nicht m�glich.");

			builder.AddOrUpdate("Shipment.AlreadyShipped",
				"This shipment is already shipped.",
				"Diese Sendung wird bereits ausgeliefert.");

			builder.AddOrUpdate("Shipment.AlreadyDelivered",
				"This shipment is already delivered.",
				"Diese Sendung wird bereits zugestellt.");

			builder.AddOrUpdate("Customer.DoesNotExist",
				"The customer does not exist.",
				"Der Kunde existiert nicht.");

			builder.AddOrUpdate("Checkout.AnonymousNotAllowed",
				"An anonymous checkout is not allowed.",
				"Ein anonymer Checkout ist nicht zul�ssig.");

			builder.AddOrUpdate("Common.Error.InvalidEmail",
				"The email address is not valid.",
				"Die E-Mail-Adresse ist ung�ltig.");

			builder.AddOrUpdate("Common.Error.NoActiveLanguage",
				"No active language could be loaded.",
				"Es wurde keine aktive Sprache gefunden.");

			builder.AddOrUpdate("Admin.OrderNotice.RecurringPaymentCancellationError",
				"Unable to cancel recurring payment for order {0}.",
				"Es ist ein Fehler bei der Stornierung einer wiederkehrenden Zahlung f�r Auftrag {0} aufgetreten.");

			builder.AddOrUpdate("Admin.OrderNotice.OrderRefundError",
				"Unable to refund order {0}.",
				"Es ist ein Fehler bei einer R�ckerstattung zu Auftrag {0} aufgetreten.");

			builder.AddOrUpdate("Admin.OrderNotice.OrderPartiallyRefundError",
				"Unable to partially refund order {0}.",
				"Es ist ein Fehler bei einer Teilerstattung zu Auftrag {0} aufgetreten.");

			builder.AddOrUpdate("Admin.OrderNotice.OrderVoidError",
				"Unable to void payment transaction of order {0}.",
				"Es ist ein Fehler bei der Stornierung einer Zahlungstransaktion zu Auftrag {0} aufgetreten.");

			builder.AddOrUpdate("Admin.Configuration.Settings.Catalog.SortFilterResultsByMatches",
				"Sort filter results by number of matches",
				"Filterergebnisse nach Trefferanzahl sortieren",
				"Specifies to sort filter results by number of matches in descending order. If this option is deactivated then the result is sorted by the display order of the values.",
				"Legt fest, das Filterergebnisse absteigend nach der Anzahl an �bereinstimmungen sortiert werden. Ist diese Option deaktiviert, so wird in der f�r die Werte festgelegten Reihenfolge sortiert.");

			builder.AddOrUpdate("Wishlist.IsDisabled",
				"The wishlist is disabled.",
				"Die Wunschliste ist deaktiviert.");

			builder.AddOrUpdate("ShoppingCart.IsDisabled",
				"The shoping cart is disabled.",
				"Der Warenkorb ist deaktiviert.");

			builder.AddOrUpdate("Products.NotFound",
				"The product {0} was not found.",
				"Das Produkt {0} wurde nicht gefunden.");

			builder.AddOrUpdate("Products.Variants.NotFound",
				"The product variant {0} was not found.",
				"Die Produktvariante {0} wurde nicht gefunden.");

			builder.AddOrUpdate("Reviews.NotFound",
				"The product review {0} was not found.",
				"Die Produktbewertung {0} wurde nicht gefunden.");

			builder.AddOrUpdate("Polls.AnswerNotFound",
				"The poll answer {0} was not found.",
				"Eine Umfrageantwort {0} wurde nicht gefunden.");

			builder.AddOrUpdate("Polls.NotAvailable",
				"The poll is not available.",
				"Die Umfrage ist nicht verf�gbar.");

			builder.AddOrUpdate("Install.LanguageNotRegistered",
				"The install language '{0}' is not registered.",
				"Die Installationssprache '{0}' ist nicht registriert.");
		}
	}
}