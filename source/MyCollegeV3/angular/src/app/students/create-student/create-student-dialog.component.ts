import {
	Component,
	Injector,
	OnInit,
	Output,
	EventEmitter
} from '@angular/core';
import { BsModalRef } from 'ngx-bootstrap/modal';
import { AppComponentBase } from '@shared/app-component-base';
import {
	CreateStudentDto,
	StudentServiceProxy
} from '@shared/service-proxies/service-proxies';

@Component({
	templateUrl: 'create-student-dialog.component.html'
})
export class CreateStudentDialogComponent extends AppComponentBase
	implements OnInit {
	saving = false;
	student: CreateStudentDto = new CreateStudentDto();

	@Output() onSave = new EventEmitter<any>();

	constructor(
		injector: Injector,
		public _studentService: StudentServiceProxy,
		public bsModalRef: BsModalRef
	) {
		super(injector);
	}

	ngOnInit(): void {
		this.student.isActive = true;
	}

	save(): void {
		this.saving = true;

		this._studentService.create(this.student).subscribe(
			() => {
				this.notify.info(this.l('SavedSuccessfully'));
				this.bsModalRef.hide();
				this.onSave.emit();
			},
			() => {
				this.saving = false;
			}
		);
	}
}

