﻿// <auto-generated />
using System;
using LMG.DAT.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LMG.DAT.Migrations
{
    [DbContext(typeof(LMG_DbContext))]
    [Migration("20220604002850_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("LMG.DAT.Models.Author.DC_Author", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Dob")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("Dod")
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(64)
                        .HasColumnType("nvarchar(64)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Author", "Author");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CreatedBy = "Me",
                            Description = "Joanne Rowling, also known by her pen name J. K. Rowling, is a British author and philanthropist. She wrote a seven-volume children's fantasy series, Harry Potter, published from 1997 to 2007.",
                            Dob = "07/31/1965",
                            FirstName = "J.K.",
                            LastName = "Rowling",
                            ModifiedBy = "Me"
                        },
                        new
                        {
                            Id = 2,
                            CreatedBy = "Me",
                            Description = "Jerome David Salinger was an American author best known for his 1951 novel The Catcher in the Rye. Before its publication, Salinger published several short stories in Story magazine and served in World War II.",
                            Dob = "01/01/1919",
                            Dod = "01/27/2010",
                            FirstName = "J.D.",
                            LastName = "Sallinger",
                            ModifiedBy = "Me"
                        },
                        new
                        {
                            Id = 3,
                            CreatedBy = "Me",
                            Description = "Chinua Achebe was a Nigerian novelist, poet, and critic who is regarded as the dominant figure of modern African literature. His first novel and magnum opus, Things Fall Apart, occupies a pivotal place in African literature and remains the most widely studied, translated and read African novel.",
                            Dob = "11/16/1930",
                            Dod = "03/21/2013",
                            FirstName = "Chinua",
                            LastName = "Achebe",
                            ModifiedBy = "Me"
                        },
                        new
                        {
                            Id = 4,
                            CreatedBy = "Me",
                            Description = "Alice Louise Waters is an American chef, restaurateur, and author. In 1971 she opened Chez Panisse, a Berkeley, California restaurant famous for its role in creating the farm-to-table movement and for pioneering California cuisine.",
                            Dob = "04/28/1944",
                            FirstName = "Alice",
                            LastName = "Waters",
                            ModifiedBy = "Me"
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.Book.DC_Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("Copies")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Edition")
                        .HasColumnType("int");

                    b.Property<string>("Genre")
                        .HasMaxLength(512)
                        .HasColumnType("nvarchar(512)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PublicationYear")
                        .HasColumnType("int");

                    b.Property<int?>("SerieId")
                        .HasColumnType("int");

                    b.Property<string>("Series")
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<string>("Summary")
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.HasKey("Id");

                    b.HasIndex("SerieId");

                    b.ToTable("Book", "Book");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Copies = 3,
                            CreatedBy = "Me",
                            Edition = 1,
                            Genre = "Fantasy",
                            ModifiedBy = "Me",
                            PublicationYear = 1997,
                            Series = "Harry Potter",
                            Summary = "A boy learns on his eleventh birthday that he is the orphaned son of two powerful wizards and possesses unique magical powers of his own. He is summoned from his life as an unwanted child to become a student at Hogwarts, an English boarding school for wizards. There, he meets several friends who become his closest allies and help him discover the truth about his parents' mysterious deaths.",
                            Title = "Harry Potter & The Socerer's Stone"
                        },
                        new
                        {
                            Id = 2,
                            Copies = 3,
                            CreatedBy = "Me",
                            Edition = 1,
                            Genre = "Fantasy",
                            ModifiedBy = "Me",
                            PublicationYear = 1998,
                            Series = "Harry Potter",
                            Summary = "The second instalment of boy wizard Harry Potter's adventures at Hogwarts School of Witchcraft and Wizardry, based on the novel by JK Rowling. A mysterious elf tells Harry to expect trouble during his second year at Hogwarts, but nothing can prepare him for trees that fight back, flying cars, spiders that talk and deadly warnings written in blood on the walls of the school.",
                            Title = "Harry Potter and the Chamber of Secrets"
                        },
                        new
                        {
                            Id = 3,
                            Copies = 5,
                            CreatedBy = "Me",
                            Edition = 1,
                            Genre = "Fiction",
                            ModifiedBy = "Me",
                            PublicationYear = 1951,
                            Series = "N/A",
                            Summary = "The novel details two days in the life of 16-year-old Holden Caulfield after he has been expelled from prep school. Confused and disillusioned, Holden searches for truth and rails against the phoniness of the adult world.",
                            Title = "The Catcher in the Rye"
                        },
                        new
                        {
                            Id = 4,
                            Copies = 5,
                            CreatedBy = "Me",
                            Edition = 1,
                            Genre = "Fiction",
                            ModifiedBy = "Me",
                            PublicationYear = 1958,
                            Series = "N/A",
                            Summary = "Things Fall Apart is the debut novel by Nigerian author Chinua Achebe, first published in 1958. It depicts pre-colonial life in the southeastern part of Nigeria and the invasion by Europeans during the late 19th century. ",
                            Title = "Things Fall Apart"
                        },
                        new
                        {
                            Id = 5,
                            Copies = 2,
                            CreatedBy = "Me",
                            Edition = 1,
                            Genre = "Non-Fiction",
                            ModifiedBy = "Me",
                            PublicationYear = 2021,
                            Series = "N/A",
                            Summary = "Since opening Chez Panisse in 1971, Alice Waters has been a kind of living legend in the movement for local food, sustainable agriculture, and seasonal cooking. In her latest work, she recounts scenes from that career that fans of hers will enjoy while championing a slow food approach to farming and eating, with an emphasis on regenerative agriculture, biodiversity, and health.",
                            Title = "We Are What We Eat: A Slow Food Manifesto"
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.BookAuthor.DC_BookAuthor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthor");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            BookId = 1
                        },
                        new
                        {
                            Id = 2,
                            AuthorId = 1,
                            BookId = 2
                        },
                        new
                        {
                            Id = 3,
                            AuthorId = 2,
                            BookId = 3
                        },
                        new
                        {
                            Id = 4,
                            AuthorId = 3,
                            BookId = 4
                        },
                        new
                        {
                            Id = 5,
                            AuthorId = 4,
                            BookId = 5
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.Borrow.DC_Borrow", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<string>("BorrowDate")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<int?>("MembersId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.HasIndex("MembersId");

                    b.ToTable("Borrow", "Borrow");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            BorrowDate = "05/17/2022",
                            MemberId = 1
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            BorrowDate = "05/12/2022",
                            MemberId = 2
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            BorrowDate = "05/17/2022",
                            MemberId = 1
                        },
                        new
                        {
                            Id = 4,
                            BookId = 3,
                            BorrowDate = "05/10/2022",
                            MemberId = 3
                        },
                        new
                        {
                            Id = 5,
                            BookId = 4,
                            BorrowDate = "05/17/2022",
                            MemberId = 1
                        },
                        new
                        {
                            Id = 6,
                            BookId = 5,
                            BorrowDate = "05/09/2022",
                            MemberId = 4
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.Member.DC_Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Birthdate")
                        .IsRequired()
                        .HasMaxLength(16)
                        .HasColumnType("nvarchar(16)");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("Gender")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<long>("Phone")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.ToTable("Member", "Member");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Birthdate = "11/15/1967",
                            FirstName = "Earl",
                            Gender = "Male",
                            LastName = "Stevens",
                            Phone = 8312124438L
                        },
                        new
                        {
                            Id = 2,
                            Birthdate = "04/28/1966",
                            FirstName = "Todd",
                            Gender = "Male",
                            LastName = "Shaw",
                            Phone = 8315142982L
                        },
                        new
                        {
                            Id = 3,
                            Birthdate = "07/11/1974",
                            FirstName = "Kimberly",
                            Gender = "Female",
                            LastName = "Jones",
                            Phone = 8316554577L
                        },
                        new
                        {
                            Id = 4,
                            Birthdate = "07/07/1993",
                            FirstName = "Khalif",
                            Gender = "Male",
                            LastName = "Malek",
                            Phone = 8054243108L
                        },
                        new
                        {
                            Id = 5,
                            Birthdate = "11/21/1995",
                            FirstName = "Amala",
                            Gender = "Female",
                            LastName = "Dlamini",
                            Phone = 8052629749L
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.Review.DC_Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MemberId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Review")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("Review", "Review");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            BookId = 1,
                            MemberId = 1,
                            Review = "This book was great."
                        },
                        new
                        {
                            Id = 2,
                            BookId = 1,
                            MemberId = 2,
                            Review = "This book was bad."
                        },
                        new
                        {
                            Id = 3,
                            BookId = 2,
                            MemberId = 3,
                            Review = "Amazing book!"
                        },
                        new
                        {
                            Id = 4,
                            BookId = 4,
                            MemberId = 4,
                            Review = "Snooze fest."
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.Series.DC_Series", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("AuthorId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("CreatedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ModifiedBy")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SeriesName")
                        .IsRequired()
                        .HasMaxLength(1024)
                        .HasColumnType("nvarchar(1024)");

                    b.Property<int>("TotalBooks")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Series", "Series");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AuthorId = 1,
                            SeriesName = "Harry Potter",
                            TotalBooks = 7
                        });
                });

            modelBuilder.Entity("LMG.DAT.Models.Book.DC_Book", b =>
                {
                    b.HasOne("LMG.DAT.Models.Series.DC_Series", "Serie")
                        .WithMany("Books")
                        .HasForeignKey("SerieId");

                    b.Navigation("Serie");
                });

            modelBuilder.Entity("LMG.DAT.Models.BookAuthor.DC_BookAuthor", b =>
                {
                    b.HasOne("LMG.DAT.Models.Author.DC_Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMG.DAT.Models.Book.DC_Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LMG.DAT.Models.Borrow.DC_Borrow", b =>
                {
                    b.HasOne("LMG.DAT.Models.Book.DC_Book", "Book")
                        .WithMany("Borrows")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LMG.DAT.Models.Member.DC_Member", "Members")
                        .WithMany("Borrows")
                        .HasForeignKey("MembersId");

                    b.Navigation("Book");

                    b.Navigation("Members");
                });

            modelBuilder.Entity("LMG.DAT.Models.Review.DC_Review", b =>
                {
                    b.HasOne("LMG.DAT.Models.Book.DC_Book", "Book")
                        .WithMany("Reviews")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");
                });

            modelBuilder.Entity("LMG.DAT.Models.Author.DC_Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("LMG.DAT.Models.Book.DC_Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("Borrows");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("LMG.DAT.Models.Member.DC_Member", b =>
                {
                    b.Navigation("Borrows");
                });

            modelBuilder.Entity("LMG.DAT.Models.Series.DC_Series", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
