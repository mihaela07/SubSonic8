﻿using System.Collections.Generic;
using System.Linq;
using Client.Common.Models.Subsonic;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
using Subsonic8.MenuItem;
using Subsonic8.Search;

namespace Client.Tests.Search
{
    [TestClass]
    public class SearchViewModelTests
    {
        private ISearchViewModel _subject;

        [TestInitialize]
        public void TestInitialize()
        {
            _subject = new SearchViewModel();
        }

        [TestMethod]
        public void CtorSetsMenuItesmViewModel()
        {
            _subject.MenuItemViewModels.Should().NotBeNull();
        }

        [TestMethod]
        public void ParameterAlbumsContainsOneAlbumWillAddToMenuItemsOneEntry()
        {
            _subject.Parameter = new SearchResultCollection
                                     {
                                         Artists = new List<ExpandedArtist>
                                                       {
                                                           new ExpandedArtist()
                                                       }
                                     };

            _subject.MenuItems.Should().HaveCount(1);
        }

        [TestMethod]
        public void ParameterArtistsContainsOneArtistWillAddToMenuItemsOneEntry()
        {
            _subject.Parameter = new SearchResultCollection
                                     {
                                         Albums = new List<Album>
                                                      {
                                                          new Album()
                                                      },
                                     };

            _subject.MenuItems.Should().HaveCount(1);
        }

        [TestMethod]
        public void ParameterSongsContainsOneSongWillAddToMenuItemsOneEntry()
        {
            _subject.Parameter = new SearchResultCollection
                                     {
                                         Songs = new List<Song>
                                                     {
                                                         new Song()
                                                     },
                                     };

            _subject.MenuItems.Should().HaveCount(1);
        }

        [TestMethod]
        public void ParameterWhenNullWillResultInMenuItemsWillContainNoEntry()
        {
            _subject.Parameter = null;

            _subject.MenuItems.Should().HaveCount(0);
        }

        [TestMethod]
        public void PopulateArtistsShouldAddMenuItems()
        {
            _subject.PopulateArtists(new List<ExpandedArtist> { new ExpandedArtist() });

            _subject.MenuItemViewModels.Should().HaveCount(1);
        }

        [TestMethod]
        public void PopulateAlbumsShouldAddMenuItems()
        {
            _subject.PopulateAlbums(new List<Album> { new Album() });

            _subject.MenuItemViewModels.Should().HaveCount(1);
        }

        [TestMethod]
        public void PopulateSongsShouldAddMenuItems()
        {
            _subject.PopulateSongs(new List<Song> { new Song() });

            _subject.MenuItemViewModels.Should().HaveCount(1);
        }

        [TestMethod]
        public void MenuItemsShouldReturnMenuItemsViewModelsGroupedByType()
        {
            const string type = "testType";
            _subject.MenuItemViewModels.Add(new MenuItemViewModel
                                                {
                                                    Type = type
                                                });

            _subject.MenuItems.Should().Contain(i => i.Any(x => x.Type == type));
        }
    }
}