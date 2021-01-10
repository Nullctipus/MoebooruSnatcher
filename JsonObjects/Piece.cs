using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MoebooruSnatcher.JsonObjects
{
    public class Piece
    {
        public Nullable<uint> id;
        public string tags;
        public int created_at;
        public int updated_at;
        public Nullable<uint> creator_id;
        public Nullable<uint> approver_id;
        public string author;
        public int change;
        public string source;
        public int score;
        public string md5;
        public int file_size;
        public string file_ext;
        public string file_url;
        public bool is_shown_in_index;
        public string preview_url;
        public int preview_width;
        public int preview_height;
        public string sample_url;
        public int sample_width;
        public int sample_height;
        public int sample_file_size;
        public string jpeg_url;
        public int jpeg_width;
        public int jpeg_height;
        public int jpeg_file_size;
        public string rating;
        public bool is_rating_locked;
        public bool has_children;
        public Nullable<int> parent_id;
        public string status;
        public int width;
        public int height;
        public bool is_held;
        public string frames_pending_string;
        public List<string> frames_pending;
        public string frames_string;
        public List<string> frames;
        public int last_noted_at;
        public int last_commented_at;
    }
}
