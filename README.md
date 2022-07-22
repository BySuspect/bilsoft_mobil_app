# bilsoft_mobil_app


## Default Font Sizes

* FontSize=```Body```
= ```16```

* FontSize=```Caption``` 
= ```12```

* FontSize=```Default``` 
= ```14```

* FontSize=```Header```
= ```96```

* FontSize=```Large```
= ```22```

* FontSize=```Medium```
= ```18```

* FontSize=```Micro```
= ```10```

* FontSize=```Small```
= ```14```

* FontSize```Subtitle```
= ```16```

* FontSize=```Title```
= ```24```

## Text Changed Eventi
```
        private void csbArama_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!String.IsNullOrEmpty(e.NewTextValue))
               [List View Adı].ItemsSource = [yerelde tanımlı itemsSource elementi].Where(x => x[eğer varsa .item ismi].ToLower().StartsWith(e.NewTextValue.ToLower())).OrderBy(x => x).ToList();
            else
                [List View Adı].ItemsSource = [yerelde tanımlı itemsSource elementi];
        }

