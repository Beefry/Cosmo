var Section = function(template) {
	this.ID = null;
	this.FormID = template.ID;
	this.SortOrder = null;
	this.Name = "";
	this.Fields = [];
	this.newFieldType = "";
};

var Field = function(section) {
	this.Type = section.newFieldType;
	this.SectionID = section.ID;
	this.Values = [];
	this.AdminField = false;

	switch (this.Type) {
		case 'textbox':
		case 'textarea':
		case 'text':
			this.hasOptions = false;
			break;
		case 'select':
		case 'checkbox':
		case 'radio':
			this.hasOptions = true;
			this.Options = [];
			break;
		case '':
			throw new Error("Please select a field type first.");
			break;
		default:
			throw new Error("Field type not supported. Type given: " + this.Type);
			break;
	}

	if (this.Type == 'text')
		this.Options = [new Option(this)];
	else
		this.Options = [];
};

var Option = function(field) {
	this.FieldID = field.ID;
	this.Value = "";
};

var Template = function () {
	this.ID = null;
	this.Name = null;
	this.Description = null;
	this.Sections = [];
};