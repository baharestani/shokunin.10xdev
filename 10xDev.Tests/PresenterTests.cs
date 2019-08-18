using System;
using Shouldly;
using Xunit;

namespace _10xDev.Tests
{
    public class PresenterTests
    {
        [Fact]
        public void Get10XDev_throws_exception_for_more_than_one_results()
        {
            var results = new[]
            {
                new[] {"name1", "name2"},
                new[] {"name2", "name1"}
            };

            var presenter = new Presenter();

            Should.Throw<InvalidOperationException>(() => presenter.Get10XDeveloper(results));
        }

        [Fact]
        public void Get10XDev_announce_firstName_if_only_one_result_found()
        {
            var results = new[]
            {
                new[]
                {
                    "Winner", "Other"
                }
            };

            var presenter = new Presenter();

            presenter.Get10XDeveloper(results).ShouldBe("The 10X Developer is Winner");
        }

        [Fact]
        public void GetLeaderBoard_throws_exception_for_more_than_one_results()
        {
            var results = new[]
            {
                new[] {"name1", "name2"},
                new[] {"name2", "name1"}
            };

            var presenter = new Presenter();

            Should.Throw<InvalidOperationException>(() => presenter.GetLeaderBoard(results));
        }

        [Fact]
        public void GetLeaderBoard_should_announce_all_names_if_single_result()
        {
            var results = new[]
            {
                new[] {"Name1", "Name2", "Name3"},
            };

            var presenter = new Presenter();
            var leaderBoard = presenter.GetLeaderBoard(results);
            leaderBoard.ShouldBe("Leader board:\n" +
                                 "1. Name1\n" +
                                 "2. Name2\n" +
                                 "3. Name3\n"
            );
        }
    }
}
