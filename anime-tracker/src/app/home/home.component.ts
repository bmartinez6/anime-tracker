import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { ApiService } from '../service/api.service';
import { AnimeModel } from '../models/anime.model';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  formValue !: FormGroup;
  animeModelObj: AnimeModel = new AnimeModel();
  animeData !: any;
  constructor(private formBuilder: FormBuilder, private api: ApiService) { }

  ngOnInit(): void {
    this.formValue = this.formBuilder.group({
      title: [''],
      watched: [],
      watching: [],
      toWatch: []
    })

    this.getAllAnime();
  }

  postAnimeDetails() {
    this.animeModelObj.title = this.formValue.value.title;
    this.animeModelObj.watched = this.formValue.value.watched;
    this.animeModelObj.watching = this.formValue.value.watching;
    this.animeModelObj.toWatch = this.formValue.value.toWatch;

    this.api.postAnime(this.animeModelObj).subscribe(res => {
      console.log(res);
      alert("Anime Added Successfully")
      let ref = document.getElementById('cancel');
      ref?.click();
      this.formValue.reset();
      this.getAllAnime();
    },
      err => {
        alert("Error. Something went wrong");
      })
  }

  getAllAnime() {
    this.api.getAnime().subscribe(res => {
      this.animeData = res;
    })
  }

  onEdit(part: any) {
    this.animeModelObj.id = part.id;
    this.formValue.controls['title'].setValue(part.title);
    this.formValue.controls['watched'].setValue(part.watched);
    this.formValue.controls['watching'].setValue(part.watching);
    this.formValue.controls['toWatch'].setValue(part.toWatch);
  }

  updateAnimeDetails() {
    this.animeModelObj.title = this.formValue.value.title;
    this.animeModelObj.watched = this.formValue.value.watched;
    this.animeModelObj.watching = this.formValue.value.watching;
    this.animeModelObj.toWatch = this.formValue.value.toWatch;

    this.api.updateAnime(this.animeModelObj, this.animeModelObj.id).subscribe(res => {
      alert("Updated Successfully");
      let ref = document.getElementById('cancel');
      ref?.click();
      this.formValue.reset();
      this.getAllAnime();
    })
  }
}
