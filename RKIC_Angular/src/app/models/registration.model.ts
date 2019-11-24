import { StickyDirection } from "@angular/cdk/table";

export class Qualification {
    serial_number:number;
    examination:string;
    yearOfPassing:string;
    examinationType:string;
    percentage:string;
    selectedSubject:string;
    instituteName:string;
    board:string;
}
export class Student {
    registrationNo:string;
    firstName:string;
    middleName:string;
    lastName:string;
    mobileNumber:string;
    gender:string;
    fatherName:string;
    motherName:string;
    dateOfBirth:string;
    parentName:string;
    religion:string;
    cast:string;
    isMinority:boolean;
    minorityDetails:string;
    stream:string;
    subject:string[];
    fatherOccupation:string;
    motherOccupation:string;
    email:string;
    permanentAddress:string;
    currentAddress:string;
    lastCollegeName:string;
    studentType:string;
    qualification : Qualification[];
}
