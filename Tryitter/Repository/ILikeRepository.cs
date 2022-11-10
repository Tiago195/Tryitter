using Tryitter.Model;

namespace Tryitter.Repository;

public interface ILikeRepository
{
  void Like(int postId, int user);
}
