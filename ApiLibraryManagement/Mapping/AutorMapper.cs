

public class AutorMapper
{
    public Autor ToEntity(AddAutorDto autorDto)
    {
        return new Autor()
        {
            Nombre = autorDto.Nombre,
            Nacionalidad = autorDto.Nacionalidad
        };
    }

}