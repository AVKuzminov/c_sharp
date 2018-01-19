using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using GoogleSearch.Interfaces;
using System.Collections.Generic;
using System.Diagnostics;

namespace GoogleSearch.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
		private string _query;
		private List<SearchResult> _results;
		private SearchResult _selectedResult;

		public string Query
		{
			get
			{
				return _query;
			}

			set
			{
				Set(() => Query, ref _query, value);
			}
		}

		public List<SearchResult> Results
		{
			get
			{
				return _results;
			}

			set
			{
				Set(() => Results, ref _results, value);
			}
		}

		public SearchResult SelectedResult
		{
			get
			{
				return _selectedResult;
			}

			set
			{
				Set(() => SelectedResult, ref _selectedResult, value);
			}
		}

		ISearchService _searchService;
		IDialogService _dialogService;

		public RelayCommand SearchCommand { get; set; }
		public RelayCommand BrowseCommand { get; set; }

		/// <summary>
		/// Initializes a new instance of the MainViewModel class.
		/// </summary>
		public MainViewModel(ISearchService searchService, IDialogService dialogService)
        {
			_searchService = searchService;
			_dialogService = dialogService;

			SearchCommand = new RelayCommand(Search, () => !string.IsNullOrWhiteSpace(_query));
			BrowseCommand = new RelayCommand(Browse, () => _selectedResult != null);

            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}
        }

		private async void Search()
		{
			try
			{
				var results = await _searchService.GetResultsAsync(_query);
				// Here it is important that we assign through a property
				Results = results;
				SelectedResult = null;
			}
			catch
			{
				// If the program ends up here check that you
				// have api key and engine id assigned
				_dialogService.ShowMessage("Error occured");
			}
		}

		private void Browse()
		{
			if (_selectedResult != null)
				Process.Start(_selectedResult.Url);
		}
	}
}